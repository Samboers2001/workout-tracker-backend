using Microsoft.EntityFrameworkCore;
using workout_tracker_backend.Data;
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
builder.Services.AddDbContext<WorkoutTrackerDbContext>(options => options.UseSqlite(Configurations.GetConnectionString("WorkoutTrackerConnection")));


builder.Services.AddScoped<IExercise,ExerciseRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
