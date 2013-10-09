namespace CreatingCustomStack
{
    using System;

    public class Demo
    {
        public static void Main()
        {
            CustomStack<int> bsd = new CustomStack<int>();
            bsd.Push(5);
            bsd.Push(3);
            bsd.Push(1);
            Console.WriteLine(bsd.Peek());
            Console.WriteLine(bsd.Pop());

            int[] arr = bsd.ToArray();

            Console.WriteLine(bsd.Pop());
        }
    }
}

