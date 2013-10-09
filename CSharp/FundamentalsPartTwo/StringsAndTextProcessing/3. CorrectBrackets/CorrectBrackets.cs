using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CorrectBrackets
{
    static void Main()
    {
        Console.Write("Enter expretion: ");
        string expr = Console.ReadLine();
        int counter = 0;
        for (int i = 0; i < expr.Length; i++)
        {
            if (expr[i] == '(')
            {
                counter++;
            }
            if (expr[i] == ')')
            {
                counter--;
            }
            if (counter < 0)
            {
                Console.WriteLine("The expression is invalid !");
                return;
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("The expression is completely valid ! ");
        }
        else
        {
            Console.WriteLine("The expression is invalid !");
        }
    }
}
