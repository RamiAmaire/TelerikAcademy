using System;

class TwoStringVariables
{
    static void Main()
    {
        string a = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine("With quatations: " + a);
        string b = "The use of quotations causes difficulties.";
        Console.WriteLine("Without quotations: " + b);
    }
}
