using System;

class MyAgeAfteTenYears
{
    static void Main()
    {
        Console.Write("Please enter your age : ");
        int Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("After 10 years you will be : " + (Age+10));
    }
}

