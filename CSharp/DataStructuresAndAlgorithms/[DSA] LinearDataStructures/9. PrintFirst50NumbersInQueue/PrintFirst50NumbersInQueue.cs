using System;
using System.Collections;
using System.Collections.Generic;

public class PrintFirst50NumbersInQueue
{
    private static void PrintNumbers(Queue<int> numbers)
    {
        int counter = 1;
        while (counter <= 50)
        {
            int currentNumber = numbers.Dequeue();
            if (counter == 50)
            {
                Console.WriteLine(currentNumber);
            }
            else
            {
                Console.Write(currentNumber + ", ");
            }

            numbers.Enqueue(currentNumber + 1);
            numbers.Enqueue(2 * currentNumber + 1);
            numbers.Enqueue(currentNumber + 2);
            counter++;
        }
    }

    public static void Main()
    {
        Queue<int> numbers = new Queue<int>();
        int startingNumber = 2;
        numbers.Enqueue(startingNumber);
        PrintNumbers(numbers);
    }
}
