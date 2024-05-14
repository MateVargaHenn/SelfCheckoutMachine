using SelfCheckoutMachine.Core.DTO;
using SelfCheckoutMachine.Core.Utils;
using SelfCheckoutMachine.Domain.Interfaces;
using SelfCheckoutMachine.Domain.Models;
using Serilog;

namespace SelfCheckoutMachine.Domain.BusinessLogics;

public class CheckoutBusinessLogic(ICheckoutRepository checkoutRepository, IStockRepository stockRepository) : ICheckoutBusinessLogic
{
    private readonly ICheckoutRepository _checkoutRepository = checkoutRepository;
    private readonly IStockRepository _stockRepository = stockRepository;
    public async Task<CreateCheckoutResponseDTO> CheckoutAsync(Checkout checkout)
    {
        
        int price = PriceHelper.RoundPrice(checkout.Price);
        checkout.Return = Math.Abs(price - checkout.Payed);

        //Save to database
        checkout = await _checkoutRepository.CheckoutAsync(checkout);

        List<Stock> stocks = await _stockRepository.ReadAllStocksAsync();
        stocks = stocks.OrderByDescending(i =>i.MoneyValue).ToList();
        CreateCheckoutResponseDTO dto = new();
        dto.Return = new();
        int returnMoney = checkout.Return;
        foreach (Stock stock in stocks)
        {
            if (returnMoney != 0 && returnMoney >= stock.MoneyValue && stock.Count > 0)
            {
                int count = returnMoney / stock.MoneyValue;
                returnMoney -= (count * stock.MoneyValue);
                dto.Return.Add(stock.MoneyValue.ToString(), count);
            }
        }
        return dto;
    }
}
