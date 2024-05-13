using SelfCheckoutMachine.Domain.Interfaces;
using SelfCheckoutMachine.Domain.Models;

namespace SelfCheckoutMachine.Infrastructure.Repositories;

public class CheckoutRepository(SelfCheckoutMachineDbContext context) : ICheckoutRepository
{
    private readonly SelfCheckoutMachineDbContext _context = context;
    public async Task<Checkout> CheckoutAsync(Checkout checkout)
    {
        await _context.Checkouts.AddAsync(checkout);
        await _context.SaveChangesAsync();
        return checkout;
    }
}
