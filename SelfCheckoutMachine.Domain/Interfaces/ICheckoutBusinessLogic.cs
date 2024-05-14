using SelfCheckoutMachine.Core.DTO;
using SelfCheckoutMachine.Domain.Models;

namespace SelfCheckoutMachine.Domain.Interfaces;

public interface ICheckoutBusinessLogic
{
    Task<CreateCheckoutResponseDTO> CheckoutAsync(Checkout checkout);
}
