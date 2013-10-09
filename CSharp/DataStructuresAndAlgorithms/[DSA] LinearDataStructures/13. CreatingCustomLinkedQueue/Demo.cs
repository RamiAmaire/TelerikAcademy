namespace CreatingCustomLinkedQueue
{
    using System;

    public class Demo
    {
        public static void Main()
        {
            LinkedQueue<int> sue = new LinkedQueue<int>();
            sue.Enqueue(5);
            sue.Enqueue(1);
            sue.Enqueue(7);

            sue.Dequeue();
        }
    }
}
