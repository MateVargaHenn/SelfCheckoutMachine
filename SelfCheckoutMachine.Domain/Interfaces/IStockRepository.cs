using SelfCheckoutMachine.Domain.Models;

namespace SelfCheckoutMachine.Domain.Interfaces;

public interface IStockRepository
{
    Task<bool> CreateStocksAsync(List<Stock> stocks);
    Task<List<Stock>> ReadAllStocksAsync();
}
