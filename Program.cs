using System.Net.WebSockets;
using Microsoft.EntityFrameworkCore;
using workout_tracker_backend.Authorization;
using workout_tracker_backend.Data;
using workout_tracker_backend.Helpers;
using workout_tracker_backend.Interfaces;
using workout_tracker_backend.Repositories;


var builder = WebApplication.CreateBuilder(args);
IConfiguration Configurations = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IExercise, ExerciseRepo>();
builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddDbContext<WorkoutTrackerDbContext>(options => options.UseSqlite(Configurations.GetConnectionString("WorkoutTrackerConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:8080").AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();

app.Use(async (context, next) => 
{
    if(context.WebSockets.IsWebSocketRequest)
    {
        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
        Console.WriteLine("Websocket Connected");
    }
    else
    {
        await next();
    }
});

app.UseHttpsRedirection();

app.UseCors("MyAllowedOrigins");

app.UseMiddleware<JwtMiddleware>();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
