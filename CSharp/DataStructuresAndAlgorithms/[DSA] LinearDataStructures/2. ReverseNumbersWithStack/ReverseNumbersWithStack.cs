using System;
using System.Collections.Generic;

public class ReverseNumbersWithStack
{
    private static Stack<int> SaveInput()
    {
        Stack<int> numbers = new Stack<int>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == string.Empty)
            {
                break;
            }
            else
            {
                numbers.Push(int.Parse(input));
            }
        }

        return numbers;
    }

    private static void PrintNumbers(Stack<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers.Pop());
            i--;
        }
    }

    public static void Main()
    {
        Stack<int> numbers = SaveInput();
        PrintNumbers(numbers);
    }
}

