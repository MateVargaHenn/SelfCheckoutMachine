namespace SelfCheckoutMachine.Core.DTO;

public class CreateCheckoutRequestDTO
{
    public Dictionary<string, int> Inserted { get; set; } = null!;
    public int Price { get; set; }
}
