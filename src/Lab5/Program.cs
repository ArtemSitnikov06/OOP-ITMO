using AdapterDataBase;
using BisnessLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ports;
using System.Reflection;

namespace Itmo.ObjectOrientedProgramming.Lab5;

public class Program
{
    public static void Main()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        builder.Services.AddControllers()
            .AddApplicationPart(
                Assembly.Load(
                    "Controllerss"));
        builder.Services.AddScoped<ATMSystem>();
        builder.Services.AddScoped<IATMService, ATMService>();
        builder.Services.AddScoped<AuthenticateSystem>();
        builder.Services.AddScoped<IBankDatabase>(с =>
        {
            string connectionString = "Host=localhost;Port=54321;Username=postgres;Password=postgres;Database=postgres";
            return new BankDataBase(connectionString);
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        app.UseSession();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATM WEB");
            c.RoutePrefix = string.Empty;
        });

        app.MapControllers();

        app.Run();
    }
}
