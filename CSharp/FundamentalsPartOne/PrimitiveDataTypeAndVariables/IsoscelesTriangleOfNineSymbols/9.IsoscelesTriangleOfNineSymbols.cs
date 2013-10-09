using System;

class IsoscelesTriangleOfNineSymbols
{
    static void Main()
    {
        int i;
        for (i = 0; i < 4; i++)
        {
            Console.Write("  " + (char)169 + "  ");
        }
        Console.WriteLine();
        for (i = 0; i < 2; i++)
        {
            Console.Write("    " + (char)169 + "      ");
        }
        Console.WriteLine();
        for (i = 0; i < 2; i++)
        {
            Console.Write("      " + (char)169);
        }
        Console.WriteLine();
        Console.WriteLine("          " + (char)169);
    }
}
