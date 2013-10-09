namespace CreatingCustomLinkedList
{
    using System;

    public class LinkedList<T>
    {
        #region Fields and Construcors
        private ListItem<T> firstElement;
        private ListItem<T> lastElement;
        private int count;

        public LinkedList()
        {
            this.firstElement = null;
            this.lastElement = null;
            this.count = 0;
        }

        #endregion

        #region Properties
        public ListItem<T> FirstElement
        {
            get
            {
                return this.firstElement;
            }

            set
            {
                this.firstElement = value;
            }
        }

        public ListItem<T> LastElement
        {
            get
            {
                return this.lastElement;
            }

            set
            {
                this.lastElement = value;
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
        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element cannot be null");
            }

            if (this.firstElement == null)
            {
                this.firstElement = new ListItem<T>(element);
                this.lastElement = this.firstElement;
            }
            else
            {
                this.lastElement = new ListItem<T>(element, this.lastElement); 
            }

            this.count++;
        }

        public int IndexOf(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element cannot be null");
            }

            int index = -1;
            int currentIndex = 0;
            ListItem<T> currentElement = this.firstElement;

            while (currentIndex < this.count)
            {
                if (currentElement.Value == (dynamic)element)
                {
                    index = currentIndex;
                    return index;
                }

                currentElement = currentElement.NextElement;
                currentIndex++;
            }

            return index;
        }

        public ListItem<T> GetElement(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentException(string.Format("Index must be between {0} and {1}", 0, this.count));
            }

            ListItem<T> currentElement = this.firstElement;
            int counter = 0;
            while (counter < index)
            {
                currentElement = currentElement.NextElement;
                counter++;
            }

            return currentElement;
        }

        private Tuple<ListItem<T>, ListItem<T>> GetCurrentAndPreviousElements(int index)
        {
            ListItem<T> currentElement = this.firstElement;
            ListItem<T> prevElement = null;
            int counter = 0;
            while (counter < index)
            {
                prevElement = currentElement;
                currentElement = currentElement.NextElement;
                counter++;
            }
            
            return new Tuple<ListItem<T>,ListItem<T>>(prevElement, currentElement);
        }

        public void Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element cannot be null");
            }

            int index = this.IndexOf(element);
            ListItem<T> currentElement = null;
            ListItem<T> prevElement = null;
            if (index != -1)
            {
                Tuple<ListItem<T>, ListItem<T>> elements = GetCurrentAndPreviousElements(index);
                currentElement = elements.Item2;
                prevElement = elements.Item1;
            }
            else
            {
                throw new ArgumentException("Such element does not exits in the current list");
            }

            // Checking if this is head
            if (prevElement == null)
            {
                this.firstElement = currentElement.NextElement;
            }
            // Checking if this is tail
            else if (currentElement.NextElement == null)
            {
                this.lastElement = prevElement;
                prevElement.NextElement = null;
            }
            else
            {
                prevElement.NextElement = currentElement.NextElement;
            }
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentException(string.Format("Index must be between {0} and {1}", 0, this.count));
            }

            if (element == null)
            {
                 throw new ArgumentNullException("Element cannot be null");
            }

            this.count++;
            ListItem<T> newElement = new ListItem<T>(element);
            ListItem<T> prevElement = GetCurrentAndPreviousElements(index).Item1;
            ListItem<T> currentElement = GetCurrentAndPreviousElements(index).Item2;

            // Checking if this is head
            if (this.IndexOf(currentElement.Value) == 0)
            {
                this.firstElement = newElement;
                newElement.NextElement = currentElement;
            }
            else
            {
                prevElement.NextElement = newElement;
                newElement.NextElement = currentElement;
            }
        }

        public ListItem<T>[] ToArray()
        {
            ListItem<T>[] elements = new ListItem<T>[this.count];
            int index = 0;
            ListItem<T> currentElement = this.firstElement;

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
