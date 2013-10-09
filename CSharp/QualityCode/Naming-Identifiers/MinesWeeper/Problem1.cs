using System;

public class Parent
{
    public const int MaxCount = 6;

    public static void ConsoleWriteTrue()
    {
        Parent.Child child = new Parent.Child();
        child.ConsoleWriteVariableAsString(true);
    }

    public class Child
    {
        public void ConsoleWriteVariableAsString(bool variable)
        {
            string variableAsString = variable.ToString();
            Console.WriteLine(variableAsString);
        }
    }
}
