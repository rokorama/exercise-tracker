using Microsoft.EntityFrameworkCore;
using exercisetracker.Data;
using exercisetracker.Services.AuthService;
using exercisetracker.Services.WorkoutService;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONN_STRING"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();
}

// app.MapGet("api/test", () => new { Test = "hello i am api" });

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();