using System;

class CalculatingRectangleArea
{
    static void Main()
    {
        Console.Write("Enter height= ");
        int height = System.Convert.ToInt32(Console.ReadLine());
        Console.Write("Entet width= ");
        int width = System.Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(new string('-', 40));
        int S;
        S = height * width;
        Console.WriteLine("Liceto e ravno = " + S);
    }
}
