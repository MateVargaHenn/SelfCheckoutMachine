using System.ComponentModel.DataAnnotations;

namespace SelfCheckoutMachine.Domain.Models;

public class Stock
{
    [Key]
    public int Id { get; set; }
    public int MoneyValue { get; set; }
    public int Count { get; set; }
}
