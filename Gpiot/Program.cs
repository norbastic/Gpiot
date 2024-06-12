using Gpiot.DB;
using Gpiot.Helpers;
using Gpiot.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var auth0Domain = builder.Configuration["Auth0_Domain"];

// Add services to the container.
builder.Services.AddSingleton<IGpioHandler, GpioHandler>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = EnvVariableHelper.GetConnectionString(builder);
builder.Services.AddDbContext<RpiDbContext>(options => options.UseNpgsql(connectionString));

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