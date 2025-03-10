using heineken.Data;
using heineken.Service;
using heineken.Service.CampaignsService;
using heineken.Service.GiftService;
using heineken.Service.LocationService;
using heineken.Service.RobotService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectio");
builder.Services.AddDbContext<MyDbHei>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRobotService, RobotService>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();



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
