using Microsoft.EntityFrameworkCore;
using SelfCheckoutMachine.Infrastructure;

namespace SelfCheckoutMachine.WebApi.Extensions;

public static class DatabaseConnectionExtension
{
    public static void AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
    {
        //Get connectionString from appsettings.json
        string connectionString = configuration.GetConnectionString("CONNECTIONSTRING")!;

        services.AddDbContextPool<SelfCheckoutMachineDbContext>(options =>
            options.UseSqlServer(connectionString)
        );

    }
}
