using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintAllLetters
{
    static void Main(string[] args)
    {
        int[] arr = new int[65536];
        //Console.WriteLine("Enter text: ");
        //string text = Console.ReadLine();
        string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla fermentum quam et metus fermentum vel tempor sapien cursus. Fusce at adipiscing metus. Cras volutpat adipiscing gravida.";
        text = text.ToLower();
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j <= char.MaxValue; j++)
            {
                if ((int)text[i] == j)
                {
                    arr[j] += 1;
                }
            }
        }
        for (int i = 97; i <= 122; i++)
        {
            Console.WriteLine((char)i + " " + "->" + " " + arr[i] + " " + "times");
            Console.WriteLine();
        }
    }
}
