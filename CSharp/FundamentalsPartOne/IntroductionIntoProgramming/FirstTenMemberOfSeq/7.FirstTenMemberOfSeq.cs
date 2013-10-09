using System;

class First10Members
{
    static void Main()
    {
        int i;
        for (i = 2; i < 12; i++)
        {
            if (i % 2 != 0)
                Console.WriteLine(-i);
            else
                Console.WriteLine(i);
        }
    }
}
