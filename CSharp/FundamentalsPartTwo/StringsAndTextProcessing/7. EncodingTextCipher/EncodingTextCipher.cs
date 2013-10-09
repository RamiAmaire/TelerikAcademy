using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter your text: ");
        string text = Console.ReadLine();
        Console.Write("Enter cipher: ");
        string cipher = Console.ReadLine();
        string[] separator = { " ", ",", "." };
        string[] resultarr = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        string result = "";
        for (int i = 0; i < resultarr.Length; i++)
        {
            result += resultarr[i];
        }
        List<int> finalResult = new List<int>();
        //encoding
        int indexEncoding = 0;
        for (int i = 0; i < result.Length; i++)
        {
            finalResult.Add(result[i] ^ cipher[indexEncoding]);
            indexEncoding++;
            if (indexEncoding==cipher.Length)
            {
                indexEncoding = 0;
            }
        }
        //decoding
        int indexDecoding = 0;
        for (int i = 0; i < finalResult.Count; i++)
        {
            Console.Write((char)(finalResult[i] ^ cipher[indexDecoding]));
            indexDecoding++;
            if (indexDecoding == cipher.Length)
            {
                indexDecoding = 0;
            }
        }
    }
}
