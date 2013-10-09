using System;

class WithinCircleAndOutOfRectangle
{
    static void Main()
    {
        Console.Write("Vuvedete purva kordinata= ");
        double x = System.Convert.ToDouble(Console.ReadLine());
        Console.Write("Vuvedete vtora kordinata= ");
        double y = System.Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(new string('-', 40));
        double r = 5;
        if (x * x + y * y <= r * r)
        {
            Console.WriteLine("Tochkata O({0},{1}) se namira v okrujnosta ", x, y);
        }
        else
        {
            Console.WriteLine("Tochkata O({0},{1}) ne se namira v okrujnosta ", x, y);
        }
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(new string('-', 40));
        Console.Write("Vuvedete purva kordinata= ");
        double a = System.Convert.ToDouble(Console.ReadLine());
        Console.Write("Vuvedete vtora kordinata= ");
        double b = System.Convert.ToDouble(Console.ReadLine());
        if ((a >= -1 && a <= 5) && (b >= 1 && b <= 5))
        {
            Console.WriteLine("Tochkata I({0},{1}) se namira v Pravougulnika ", a, b);
        }
        else
        {
            Console.WriteLine("Tochkata I({0},{1}) ne se namira v Pravougulnika ", a, b);
        }
    }
}
