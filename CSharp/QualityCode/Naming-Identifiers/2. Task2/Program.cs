using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main()
    {
        Random randomGenerator = new Random();
        int randomAge = randomGenerator.Next(0, 100);

        Human pesho = CreatureMashine.MakeHuman(randomAge);

        Console.WriteLine(pesho.Sex);
    }
}
