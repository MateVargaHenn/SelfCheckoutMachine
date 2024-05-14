using System.ComponentModel.DataAnnotations;

namespace SelfCheckoutMachine.Domain.Models;

public class Checkout
{
    [Key]
    public int Id { get; set; }
    public int Price { get; set; }
    public int Payed { get; set; }
    public int Return { get; set; } = 0;

}
