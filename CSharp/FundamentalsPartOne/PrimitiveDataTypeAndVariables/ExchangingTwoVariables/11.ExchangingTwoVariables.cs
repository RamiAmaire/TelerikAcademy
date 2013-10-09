using System;
class ExchangingTwoVariables
{
static void Main()
{
    int a = 5;
    int b = 10;
    int x;
    x = a;
    a = b;
    b = x;
    Console.WriteLine("a= " + a + Environment.NewLine + "b= " + b);
}
}
