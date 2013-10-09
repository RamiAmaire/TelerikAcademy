using System;

class isMale
{
    static void Main()
    {
        bool isMale;
        Console.Write("Enter your Gender, type Male of Female: ");
        string m = Console.ReadLine();
        if (m == "Male")
        {
            isMale = true;
        }
        else
        {
            isMale = false;
        }
        Console.WriteLine(isMale);
    }
}
