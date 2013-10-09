namespace CreatingCustomLinkedList
{
    using System;

    public class Demo
    {
        public static void Main()
        {
            LinkedList<int> asd = new LinkedList<int>();
            asd.Add(5);
            asd.Add(1);
            asd.Add(7);

            asd.Insert(0, 21);
            asd.Insert(1, 27);

            Console.WriteLine(asd.GetElement(0).Value);
            Console.WriteLine(asd.GetElement(1).Value);
            Console.WriteLine(asd.GetElement(2).Value);

            Console.WriteLine();
            Console.WriteLine(asd.FirstElement.Value);
            Console.WriteLine(asd.LastElement.Value);

            ListItem<int>[] elements = asd.ToArray();
        }
    }
}
