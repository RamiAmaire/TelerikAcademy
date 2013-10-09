using System;
class ComparingFloatingNumbers
{
    static void Main()
    {
        Console.Write("Enter number type double = ");
        double firstnumber = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter second number type double = ");
        double secondnumber = Convert.ToDouble(Console.ReadLine());
        bool equal = (firstnumber == secondnumber);
        Console.WriteLine("The result is : " + equal);
    }
}
