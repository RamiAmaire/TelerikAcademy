using System;
class ExchangingBits345With242526
{
    static void SwapByRef(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }
    static void Main()
    {
        Console.Write("Enter a number= ");
        int n = System.Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Number in binary= " + System.Convert.ToString(n, 2));
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(new string('-', 40));
        int m = 1;
        m = 1 << 3; //bit3
        int bit3;
        bit3 = n & m;
        m = 1 << 4; //bit 4
        int bit4;
        bit4 = n & m;
        m = 1 << 5; //bit 5
        int bit5;
        bit5 = n & m;
        m = 1 << 24; //bit 24
        int bit24;
        bit24 = n & m;
        m = 1 << 25; //bit 25
        int bit25;
        bit25 = n & m;
        m = 1 << 26; //bit 26
        int bit26;
        bit26 = n & m;
        Console.WriteLine("Before bit5= " + System.Convert.ToString(bit5, 2));
        Console.WriteLine("Before bit26= " + System.Convert.ToString(bit26, 2));
        Console.WriteLine(new string('-', 40));
        SwapByRef(ref bit3, ref bit24);
        SwapByRef(ref bit4, ref bit25);
        SwapByRef(ref bit5, ref bit26);
        Console.WriteLine("after bit5= " + System.Convert.ToString(bit5, 2));
        Console.WriteLine("after bit26= " + System.Convert.ToString(bit26, 2));
    }
}
