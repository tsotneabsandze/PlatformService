using AutoMapper;
using PlatformService;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Infrastructure;
using PlatformService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.ConfigureMiddlewares();


app.RegisterEndpoints();


app.Run();

