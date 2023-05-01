// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpaceXProxyAPI.Clients;
using SpaceXProxyAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

// Getting baseURl from the appsettings
var baseUrl = builder.Configuration.GetValue<string>("spacexInternalApiBaseUrl");

// Add services to the container.
services.AddSingleton(_ => new RestClient(baseUrl));
services.AddScoped<LaunchClient>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var corsUrl = builder.Configuration.GetSection("AllowedDomains:Urls").Get<List<string>>() ?? new List<string> { };

services.AddCors(options =>
{
    options.AddPolicy("Cors", p =>
    {
        p.WithOrigins(corsUrl.ToArray())
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
