using System;

class AstrologicalDigits
{
    static void Main()
    {
        string n = Console.ReadLine();
        int sum = 0;
        for (int i = 0; i < n.Length; i++)
        {
            if (n[i] != '.' && n[i] != '-')
            {
                sum += int.Parse(n[i].ToString());
            }
        }
        int tempn = sum;

        while (sum > 9)
        {
            tempn = sum;
            sum = 0;
            do
            {
                int currentDigit = tempn % 10;
                tempn /= 10;
                sum += currentDigit;
            }
            while (tempn != 0);
        }
        Console.WriteLine(sum);
    }
}

