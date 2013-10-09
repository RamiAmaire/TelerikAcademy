using System;
using System.Diagnostics;

public class Program
{
    public static void DisplayExecutionTime(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
        Console.WriteLine(new string('-', 40));
    }

    public static void Main()
    {
        DisplayExecutionTime(() =>
        {
            GenericType<double>.Divide(1111111111);
        });
    }
}
