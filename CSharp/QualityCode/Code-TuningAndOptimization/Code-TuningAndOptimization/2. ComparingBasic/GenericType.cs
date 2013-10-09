using System;

public class GenericType<T>
{
    private static T number;

    // Operations
    #region Adding
    public static void Add(long endValue)
    {
        Console.WriteLine("Adding");
        Console.WriteLine(new string('-', 40));
        string typeName = number.GetType().Name;

        if (typeName == "Int32")
        {
            Console.WriteLine("Int : ");
            int num = 0;
            for (int i = 0; i < endValue; i++)
            {
                num += 1;
            }
        }

        if (typeName == "Int64")
        {
            Console.WriteLine("Long : ");
            long num = 0;
            for (long i = 0; i < endValue; i++)
            {
                num += 1;
            }
        }

        if (typeName == "Single")
        {
            Console.WriteLine("Float : ");
            float num = 0;
            for (float i = 0; i < endValue; i++)
            {
                num += 1;
            }
        }

        if (typeName == "Double")
        {
            Console.WriteLine("Double : ");
            double num = 0;
            for (double i = 0; i < endValue; i++)
            {
                num += 1;
            }
        }

        if (typeName == "Decimal")
        {
            Console.WriteLine("Decimal : ");
            decimal num = 0;
            for (decimal i = 0; i < endValue; i++)
            {
                num += 1;
            }
        }
    }
    #endregion

    #region Substracting
    public static void Substract(long endValue)
    {
        Console.WriteLine("Substracting");
        Console.WriteLine(new string('-', 40));
        string typeName = number.GetType().Name;

        if (typeName == "Int32")
        {
            Console.WriteLine("Int : ");
            int num = 0;
            for (int i = 0; i < endValue; i++)
            {
                num -= 1;
            }
        }

        if (typeName == "Int64")
        {
            Console.WriteLine("Long : ");
            long num = 0;
            for (long i = 0; i < endValue; i++)
            {
                num -= 1;
            }
        }

        if (typeName == "Single")
        {
            Console.WriteLine("Float : ");
            float num = 0;
            for (float i = 0; i < endValue; i++)
            {
                num -= 1;
            }
        }

        if (typeName == "Double")
        {
            Console.WriteLine("Double : ");
            double num = 0;
            for (double i = 0; i < endValue; i++)
            {
                num -= 1;
            }
        }

        if (typeName == "Decimal")
        {
            Console.WriteLine("Decimal : ");
            decimal num = 0;
            for (decimal i = 0; i < endValue; i++)
            {
                num -= 1;
            }
        }
    }
    #endregion

    #region Incrementing
    public static void Increment(long endValue)
    {
        Console.WriteLine("Incrementing");
        Console.WriteLine(new string('-', 40));
        string typeName = number.GetType().Name;

        if (typeName == "Int32")
        {
            Console.WriteLine("Int : ");
            for (int i = 0; i < endValue; i++)
            {
                i++;
            }
        }

        if (typeName == "Int64")
        {
            Console.WriteLine("Long : ");
            for (long i = 0; i < endValue; i++)
            {
                i++;
            }
        }

        if (typeName == "Single")
        {
            Console.WriteLine("Float : ");
            for (float i = 0; i < endValue; i++)
            {
                i++;
            }
        }

        if (typeName == "Double")
        {
            Console.WriteLine("Double : ");
            for (double i = 0; i < endValue; i++)
            {
                i++;
            }
        }

        if (typeName == "Decimal")
        {
            Console.WriteLine("Decimal : ");
            for (decimal i = 0; i < endValue; i++)
            {
                i++;
            }
        }
    }
    #endregion

    #region Multiplying
    public static void Multiply(long endValue)
    {
        Console.WriteLine("Multiplying");
        Console.WriteLine(new string('-', 40));
        string typeName = number.GetType().Name;

        if (typeName == "Int32")
        {
            Console.WriteLine("Int : ");
            int num = 1;
            int num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num *= num1;
            }
        }

        if (typeName == "Int64")
        {
            Console.WriteLine("Long : ");
            long num = 1;
            long num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num *= num1;
            }
        }

        if (typeName == "Single")
        {
            Console.WriteLine("Float : ");
            float num = 1;
            float num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num *= num1;
            }
        }

        if (typeName == "Double")
        {
            Console.WriteLine("Double : ");
            double num = 1;
            double num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num *= num1; ;
            }
        }

        if (typeName == "Decimal")
        {
            Console.WriteLine("Decimal : ");
            decimal num = 1;
            decimal num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num *= num1;
            }
        }
    }
    #endregion

    #region Dividing
    public static void Divide(long endValue)
    {
        Console.WriteLine("Dividing");
        Console.WriteLine(new string('-', 40));
        string typeName = number.GetType().Name;

        if (typeName == "Int32")
        {
            Console.WriteLine("Int : ");
            int num = 1;
            int num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num /= num1;
            }
        }

        if (typeName == "Int64")
        {
            Console.WriteLine("Long : ");
            long num = 1;
            long num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num /= num1;
            }
        }

        if (typeName == "Single")
        {
            Console.WriteLine("Float : ");
            float num = 1;
            float num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num /= num1;
            }
        }

        if (typeName == "Double")
        {
            Console.WriteLine("Double : ");
            double num = 1;
            double num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num /= num1;
            }
        }

        if (typeName == "Decimal")
        {
            Console.WriteLine("Decimal : ");
            decimal num = 1;
            decimal num1 = 1;
            for (int i = 1; i < endValue; i++)
            {
                num /= num1;
            }
        }
    }
    #endregion
}
