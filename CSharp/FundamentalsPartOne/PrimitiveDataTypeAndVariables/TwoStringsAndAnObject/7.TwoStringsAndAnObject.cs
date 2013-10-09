using System;

class TwoStringsAndAnObject
{
    static void Main()
    {
        string one = "Hello";
        string two = "World";
        object oneplustwo = one+ " " + two + " !";
        string three = oneplustwo.ToString();
        Console.WriteLine(three);
    }
}

