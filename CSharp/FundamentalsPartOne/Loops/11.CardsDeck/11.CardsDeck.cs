using System;

class CardsDeck
{
    static void Main()
    {
        int i;
        int m = 1;
        int n;
        char a = 'b';
        for (n = 2; n <= 10; n++)
        {
            switch (n)
            {
                case 2: n = 2; break;
                case 3: n = 3; break;
                case 4: n = 4; break;
                case 5: n = 5; break;
                case 6: n = 6; break;
                case 7: n = 7; break;
                case 8: n = 8; break;
                case 9: n = 9; break;
                case 10: n = 10; break;
            }
            for (m = 1; m <= 4; m++)
            {
                switch (m)
                {
                    case 1: Console.WriteLine(n + "Spatiq"); break;
                    case 2: Console.WriteLine(n + "Diamond"); break;
                    case 3: Console.WriteLine(n + "Club"); break;
                    case 4: Console.WriteLine(n + "Spade"); break;
                }
            }
            Console.WriteLine();
        }
        for (i = 11; i <= 14; i++)
        {
            switch (i)
            {
                case 11: a = 'J'; break;
                case 12: a = 'Q'; break;
                case 13: a = 'K'; break;
                case 14: a = 'A'; break;
            }
            for (m = 1; m <= 4; m++)
            {
                switch (m)
                {
                    case 1: Console.WriteLine(a + "Spatiq"); break;
                    case 2: Console.WriteLine(a + "Diamond"); break;
                    case 3: Console.WriteLine(a + "Club"); break;
                    case 4: Console.WriteLine(a + "Spade"); break;
                }
            }
            Console.WriteLine();
        }
    }
}
