namespace CreatingCustomLinkedList
{
    using System;

    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextElement;

        public ListItem(T value)
        {
            this.Value = value;
            this.NextElement = null;
        }

        public ListItem(T value, ListItem<T> nextElement)
        {
            this.Value = value;
            nextElement.nextElement = this;
        }

        public T Value 
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public ListItem<T> NextElement 
        {
            get
            {
                return this.nextElement;
            }

            set
            {
                this.nextElement = value;
            }
        }
    }
}
