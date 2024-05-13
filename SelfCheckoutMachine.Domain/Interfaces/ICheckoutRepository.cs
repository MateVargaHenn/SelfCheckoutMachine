using SelfCheckoutMachine.Domain.Models;

namespace SelfCheckoutMachine.Domain.Interfaces;

public interface ICheckoutRepository
{
   Task<Checkout> CheckoutAsync(Checkout checkout);
}
