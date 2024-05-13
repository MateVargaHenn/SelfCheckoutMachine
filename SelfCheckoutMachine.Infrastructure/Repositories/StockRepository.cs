using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SelfCheckoutMachine.Domain.Interfaces;
using SelfCheckoutMachine.Domain.Models;

namespace SelfCheckoutMachine.Infrastructure.Repositories;

public class StockRepository(SelfCheckoutMachineDbContext context, ILogger<StockRepository> logger) : IStockRepository
{
    private readonly SelfCheckoutMachineDbContext _context = context;
    private readonly ILogger<StockRepository> _logger = logger;
    public async Task<bool> CreateStocksAsync(List<Stock> stocks)
    {
        _logger.LogInformation("Iterate on the stocks list.");
        foreach (Stock stock in stocks)
        {
            Stock? stockEntity = await _context.Stocks.SingleOrDefaultAsync(i => i.MoneyValue == stock.MoneyValue);
            if (stockEntity != null)
            {
                stockEntity.Count += stock.Count;
            }
            else
            {
                _context.Stocks.Add(stock);
            }
        }
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Stock>> ReadAllStocksAsync()
    {
        return await _context.Stocks.ToListAsync();
    }
}
