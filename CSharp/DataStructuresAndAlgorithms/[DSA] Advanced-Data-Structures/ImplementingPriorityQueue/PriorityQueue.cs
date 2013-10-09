namespace ImplementingPriorityQueue
{
    using System;
    using System.Linq;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 8;
        private int capacity;
        private T[] array;
        private int size;

        public PriorityQueue()
        {
            this.capacity = DEFAULT_CAPACITY;
            this.array = new T[this.capacity];
            this.size = 0;
        }

        public PriorityQueue(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Size must be atleast 1.");
            }

            this.array = new T[size];
            this.size = 0;
            this.capacity = size;
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public void Enqueue(T item)
        {
            if (this.size >= this.capacity)
            {
                this.Resize();
            }

            this.array[this.size] = item;
            this.ShiftUp();
            this.size++;
        }

        public T Dequeue()
        {
            if (this.size <= 0)
            {
                throw new ArgumentOutOfRangeException("Size must be atleast 1.");
            }

            T highestPriorityElement = this.array[0];
            this.array[0] = this.array[this.size - 1];
            this.size--;
            this.ShiftDown();
            return highestPriorityElement;
        }

        public T Peek()
        {
            if (this.size <= 0)
            {
                throw new ArgumentException("Cannot peek into empty priority queue!");
            }

            return this.array[0];
        }

        private void Resize()
        {
            this.capacity = this.capacity * 2;
            T[] newArray = new T[this.capacity];
            for (int i = 0; i < this.size; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        private void ShiftUp()
        {
            int currentPosition = this.size;
            int parentPosition = (currentPosition - 1) / 2;
            while (currentPosition > 0)
            {
                if (this.array[currentPosition].CompareTo(this.array[parentPosition]) > 0)
                {
                    this.Swap(ref this.array[currentPosition], ref this.array[parentPosition]);
                }
                else
                {
                    return;
                }

                currentPosition = parentPosition;
                parentPosition = (currentPosition - 1) / 2;
            }
        }

        private void ShiftDown()
        {
            int currentPosition = 0;
            int leftChildPosition = (currentPosition * 2) + 1;
            int rightChildPosition = leftChildPosition + 1;

            while (leftChildPosition < this.size)
            {
                int index = leftChildPosition;

                if (rightChildPosition < this.size &&
                    this.array[leftChildPosition].CompareTo(this.array[rightChildPosition]) < 0)
                {
                    index = rightChildPosition;
                }

                if (this.array[currentPosition].CompareTo(this.array[index]) > 0)
                {
                    return;
                }

                this.Swap(ref this.array[currentPosition], ref this.array[index]);

                leftChildPosition = (index * 2) + 1;
                rightChildPosition = leftChildPosition + 1;
                currentPosition = index;
            }
        }

        private void Swap(ref T first, ref T second)
        {
            T oldValue = first;
            first = second;
            second = oldValue;
        }
    }
}