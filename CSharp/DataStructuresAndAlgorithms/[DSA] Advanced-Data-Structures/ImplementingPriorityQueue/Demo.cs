namespace ImplementingPriorityQueue
{
    using System;

    public class Demo
    {
        public static void Main()
        {
            PriorityQueue<int> que = new PriorityQueue<int>();
            que.Enqueue(5);
            que.Enqueue(2);
            que.Enqueue(3);
            que.Enqueue(1);

            while (que.Count > 0)
            {
                Console.WriteLine(que.Dequeue());
            }
        }
    }
}
