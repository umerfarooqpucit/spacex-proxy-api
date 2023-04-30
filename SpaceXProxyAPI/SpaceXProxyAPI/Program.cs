// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text.Json;
using SpaceXProxyAPI.Helpers;
using SpaceXProxyAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

// Getting baseURl from the appsettings
var baseUrl = builder.Configuration.GetValue<string>("spacexInternalApiBaseUrl");

// Add services to the container.
services.AddSingleton(_ => new RestClient(baseUrl));
services.AddScoped<LaunchService>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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
