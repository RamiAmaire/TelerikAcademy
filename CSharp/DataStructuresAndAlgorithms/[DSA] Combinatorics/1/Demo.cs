using System;
using System.Numerics;

public class Demo
{
    public static void Main()
    {
        string input = Console.ReadLine();
        decimal counter = 0;
        decimal value = 2;

        if (!input.Contains("*"))
        {
            Console.WriteLine(1);
        }
        else
        {
            int index = input.IndexOf('*');
            while (index != -1)
            {
                counter++;
                index = input.IndexOf("*", index + 1);
            }

            if (counter == 1)
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine(Math.Pow((double)value, (double)counter));
            }
        }
    }
}

