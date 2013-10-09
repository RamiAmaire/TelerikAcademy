namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Demo
    {
        public static void Main()
        {
            var collection = new SortableCollection<int>(new[] { 13, 29, 22, 11, 7, 33, 0, 101 });
            Console.WriteLine("All items before sorting:");
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            //Console.WriteLine("SelectionSorter result:");
            //collection.Sort(new SelectionSorter<int>());
            //collection.PrintAllItemsOnConsole();
            //Console.WriteLine();

            //Console.WriteLine("Quicksorter result:");
            //collection.Sort(new Quicksorter<int>());
            //collection.PrintAllItemsOnConsole();
            //Console.WriteLine();

            //Console.WriteLine("MergeSorter result:");
            //collection.Sort(new MergeSorter<int>());
            //collection.PrintAllItemsOnConsole();
            //Console.WriteLine();

            //Console.WriteLine("Linear search 101:");
            //Console.WriteLine(collection.LinearSearch(101));
            //Console.WriteLine();

            //Console.WriteLine("Binary search 101:");
            //Console.WriteLine(collection.BinarySearch(101));
            //Console.WriteLine();

            Console.WriteLine("Shuffle:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Shuffle again:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Shuffle again:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
        }
    }
}
