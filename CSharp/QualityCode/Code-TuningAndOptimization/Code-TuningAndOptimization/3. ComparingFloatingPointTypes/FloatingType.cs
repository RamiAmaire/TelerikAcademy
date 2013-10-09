using System;

public class FloatingType<T>
{
    private static T number;

    // Operations
    #region Square root
    public static void Sqrt(long endValue)
    {
        Console.WriteLine("Sqrt : ");
        Console.WriteLine(new string('-', 40));
        string typeName = number.GetType().Name;

        if (typeName == "Single")
        {
            Console.WriteLine("Float : ");
            for (float i = 1; i < endValue; i++)
            {
                Math.Sqrt((double)i);
            }
        }

        if (typeName == "Double")
        {
            Console.WriteLine("Double : ");
            for (double i = 1; i < endValue; i++)
            {
                Math.Sqrt(i);
            }
        }

        if (typeName == "Decimal")
        {
            Console.WriteLine("Decimal : ");
            for (decimal i = 1; i < endValue; i++)
            {
                Math.Sqrt((double)i);
            }
        }
    }
    #endregion

    #region Natural logarithm
    public static void Log(long endValue)
    {
        Console.WriteLine("Log : ");
        Console.WriteLine(new string('-', 40));
        string typeName = number.GetType().Name;

        if (typeName == "Single")
        {
            Console.WriteLine("Float : ");
            for (float i = 1; i < endValue; i++)
            {
                Math.Log(i);
            }
        }

        if (typeName == "Double")
        {
            Console.WriteLine("Double : ");
            for (double i = 1; i < endValue; i++)
            {
                Math.Log(i);
            }
        }

        if (typeName == "Decimal")
        {
            Console.WriteLine("Decimal : ");
            for (decimal i = 1; i < endValue; i++)
            {
                Math.Log((double)i);
            }
        }
    }
    #endregion

    #region Sinus
    public static void Sin(long endValue)
    {
        Console.WriteLine("Sin : ");
        Console.WriteLine(new string('-', 40));
        string typeName = number.GetType().Name;

        if (typeName == "Single")
        {
            Console.WriteLine("Float : ");
            for (float i = 1; i < endValue; i++)
            {
                Math.Sin(i);
            }
        }

        if (typeName == "Double")
        {
            Console.WriteLine("Double : ");
            for (double i = 1; i < endValue; i++)
            {
                Math.Sin(i);
            }
        }

        if (typeName == "Decimal")
        {
            Console.WriteLine("Decimal : ");
            for (decimal i = 1; i < endValue; i++)
            {
                Math.Sin((double)i);
            }
        }
    }
    #endregion
}
