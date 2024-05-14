namespace SelfCheckoutMachine.Core.Utils;

public static class PriceHelper
{
    public static int RoundPrice(int price)
    {
        int remainder = price % 5;
        if (remainder == 0)
        {
            return price;
        }
        else if (remainder < 3)
        {
            return price - remainder;
        }
        else
        {
            return price + (5 - remainder);
        }
    }
}
