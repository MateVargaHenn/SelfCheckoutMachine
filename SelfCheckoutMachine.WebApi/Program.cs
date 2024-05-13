using AutoMapper;
using Microsoft.AspNetCore.Components;
using SelfCheckoutMachine.WebApi.Extensions;
using SelfCheckoutMachine.WebApi.Middlewares;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//Define a database connection:
builder.Services.AddDatabaseConnection(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
//Registered as an Extension.
builder.Services.AddTransients();
builder.Services.AddAutoMapper(typeof(MapperConfiguration));


builder.Services.AddSwaggerGen();

var app = builder.Build();
app.ConfigureSwagger();
// Register the exception handling middleware globally
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();