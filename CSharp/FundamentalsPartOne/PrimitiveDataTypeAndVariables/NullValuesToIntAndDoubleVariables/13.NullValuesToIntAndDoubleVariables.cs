using System;

class NullValuesToIntAndDoubleVariables
{
static void Main()
{
int? Number = null;
Console.WriteLine("Nullable int = " + Number);
Number = 7;
Console.WriteLine("Normal int is = " + Number + Environment.NewLine + new string('-', 40));
double? Number1 = null;
Console.WriteLine("Nullable double = " + Number1);
Number1 = 3.7;
Console.WriteLine("Normal double is = " + Number1);
}
}
