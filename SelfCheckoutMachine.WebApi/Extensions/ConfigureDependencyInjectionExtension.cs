using SelfCheckoutMachine.Domain.BusinessLogics;
using SelfCheckoutMachine.Domain.Interfaces;
using SelfCheckoutMachine.Infrastructure.Repositories;

namespace SelfCheckoutMachine.WebApi.Extensions;

public static class ConfigureDependencyInjectionExtension
{
    public static void AddTransients(this IServiceCollection services)
    {
        services.AddTransient<IStockRepository, StockRepository>();
        services.AddTransient<ICheckoutRepository, CheckoutRepository>();
        services.AddTransient<ICheckoutBusinessLogic, CheckoutBusinessLogic>();
    }
}
