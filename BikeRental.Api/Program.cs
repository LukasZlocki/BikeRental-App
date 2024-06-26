using BikeRental.Api;
using BikeRental.Api.Hubs;
using BikeRental.Models;
using BikeRental.Services.Resource_Service;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
//builder.Services.AddHostedService<ServerTimeNotifier>();
builder.Services.AddCors();

// Configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

// Database configuration
builder.Services.AddDbContext<RentalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<RentalDbContext>();
builder.Services.AddScoped<ResourceService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<FramesizeService>();
builder.Services.AddScoped<ReservationTicketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// maping hosted port for docker purpose
app.MapGet("/", () =>
{
    var urls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://+8080";
    Console.WriteLine($"Hosted URLs: {urls}");
    return "Hello, from Backend!";
});

// auto seeding database if no data included in db.
PrepDB.PrepPopulation(app);

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapPost("broadcast", async (string message, IHubContext<ChatHub, IChatClient> context) =>
{
    await context.Clients.All.ReceiveMessage(message);
    return Results.NoContent();
});

app.MapHub<ChatHub>("chat-hub");
app.MapHub<NotificationsHub>("notifications");

app.Run();
