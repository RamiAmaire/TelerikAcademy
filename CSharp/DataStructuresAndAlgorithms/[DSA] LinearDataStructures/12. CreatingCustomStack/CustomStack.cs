namespace CreatingCustomStack
{
    using System;

    public class CustomStack<T>
    {
        private T[] holder;
        private int count;

        public CustomStack()
        {
            this.count = 0;
            this.holder = new T[1];
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        private T[] SaveData()
        {
            T[] dataStorage = this.holder;
            return dataStorage;
        }

        private void RestoreData(T[] arr)
        {
            int holderIndex = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                this.holder[holderIndex++] = arr[i];
            }
        }

        private void IncreaseCapacity()
        {
            T[] dataStorage = this.SaveData();
            this.holder = new T[this.count];
            this.RestoreData(dataStorage);
        }

        private void DecreaseCapacity()
        {
            this.count--;
            this.holder = new T[this.count];
        }

        public void Push(T item)
        {
            this.count++;
            if (count > 1)
            {
                this.IncreaseCapacity();
            }
            
            this.holder[0] = item;
        }

        public T Peek()
        {
            return this.holder[0];
        }

        public T Pop()
        {
            T item = this.holder[0];
            T[] dataStorage = this.SaveData();
            this.DecreaseCapacity();

			int index = 1;
            for (int i = 0; i < this.holder.Length; i++)
            {
                this.holder[i] = dataStorage[index++];
            }

            return item;
        }

        public T[] ToArray()
        {
            return this.holder;
        }
    }
}
