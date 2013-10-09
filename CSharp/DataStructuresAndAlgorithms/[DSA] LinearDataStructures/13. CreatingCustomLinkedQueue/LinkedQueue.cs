namespace CreatingCustomLinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        #region Fields and Construcors
        private QueueItem<T> head;
        private QueueItem<T> tail;
        private int count;

        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        #endregion

        #region Properties
        public QueueItem<T> Tail
        {
            get
            {
                return this.tail;
            }

            set
            {
                this.tail = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
            }
        }

        #endregion

        #region Methods
        public void Enqueue(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element cannot be null");
            }

            if (this.head == null)
            {
                this.head = new QueueItem<T>(element);
                this.tail = this.head;
            }
            else
            {
                this.tail = new QueueItem<T>(element, this.tail); 
            }

            this.count++;
        }

        public QueueItem<T> Dequeue()
        {
            QueueItem<T> element = this.head;
            QueueItem<T> currentElement = this.head.NextElement;
            this.head = currentElement;
            if (currentElement == null)
            {
                this.tail = currentElement;
            }

            this.count--;
            return element;
        }

        public T Peek()
        {
            return this.head.Value;
        }

        public void Clear()
        {
            QueueItem<T> currentItem = this.head;
            QueueItem<T> prevItem = null;
            int index = 0;

            while (index < this.count)
            {
                prevItem = currentItem;
                prevItem.NextElement = null;
                prevItem = null;
                currentItem = currentItem.NextElement;
                index++;
            }

            prevItem = currentItem;
            prevItem.NextElement = null;
            prevItem = null;
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public bool Contains(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element cannot be null");
            }

            bool contains = false;
            QueueItem<T> currentElement = this.head;
            while (currentElement != null)
            {
                if (currentElement.Value == (dynamic)element)
                {
                    contains = true;
                    return contains;
                }

                currentElement = currentElement.NextElement;
            }

            return contains;
        }

        public QueueItem<T> GetElement(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentException(string.Format("Index must be between {0} and {1}", 0, this.count));
            }

            QueueItem<T> currentElement = this.head;
            int counter = 0;
            while (counter < index)
            {
                currentElement = currentElement.NextElement;
                counter++;
            }

            return currentElement;
        }

        public QueueItem<T>[] ToArray()
        {
            QueueItem<T>[] elements = new QueueItem<T>[this.count];
            int index = 0;
            QueueItem<T> currentElement = this.head;

            while (currentElement != null)
            {
                elements[index++] = currentElement;
                currentElement = currentElement.NextElement;
            }

            return elements;
        }

        #endregion
    }
}
