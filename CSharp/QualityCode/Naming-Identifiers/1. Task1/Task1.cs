using System;

public class BoolExtention
{
    private const int MaxCount = 6;

    public static void Main()
    {
        BoolExtention.Methods instance = new BoolExtention.Methods();
        instance.PrintBoolAsString(true);
    }

    public class Methods
    {
        public void PrintBoolAsString(bool currentBool)
        {
            string currentBoolAsString = currentBool.ToString();
            Console.WriteLine(currentBoolAsString);
        }
    }
}