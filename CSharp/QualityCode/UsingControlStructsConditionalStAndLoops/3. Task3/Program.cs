using System;

public class Program
{
    public const int ExpectedNumber = 7;

    private static void Main()
    {
        int[] numbers = new int[] { 2, 5, 9, 2, 1, 7 };

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == ExpectedNumber)
            {
                Console.WriteLine("Expected number Found" + " = " + numbers[i]);
                break;
            }
            
            Console.Write(numbers[i] + ", ");
        }
    }
}
