using System;

public class Program
{
    private static void Main()
    {
        Chef gosho = new Chef("Georgi", "Oklahoma");

        Potato potato = new Potato(0.5, 0.3m);

        if (potato == null)
        {
            throw new ArgumentNullException("Vegetable item cannot be null");
        }

        if (!potato.IsPeeled && potato.IsRotten)
        {
            throw new ArgumentException(
                "Vegetable must be not rotten and peeled before cooking");
        }

        gosho.Cook(potato);
    }
}
