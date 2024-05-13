using AutoMapper;
using Microsoft.AspNetCore.Components;
using SelfCheckoutMachine.WebApi.Extensions;
using SelfCheckoutMachine.WebApi.Middlewares;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(MapperConfiguration));
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.ConfigureSwagger();
// Register the exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();