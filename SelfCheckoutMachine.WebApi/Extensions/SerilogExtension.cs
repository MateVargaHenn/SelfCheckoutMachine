using Microsoft.Extensions.Hosting;
using Serilog;

namespace SelfCheckoutMachine.WebApi.Extensions;
/// <summary>
/// An extension for logging information. Further information, see the appsettings.json
/// </summary>
public static class SerilogExtension
{
    public static void AddSerilog(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, config) =>
        {
            config
            .ReadFrom.Configuration(context.Configuration)
            .WriteTo.Console();
        });
    }
}
