namespace CreatingCustomLinkedQueue
{
    using System;

    public class QueueItem<T>
    {
        private T value;
        private QueueItem<T> nextElement;

        public QueueItem(T value)
        {
            this.Value = value;
            this.NextElement = null;
        }

        public QueueItem(T value, QueueItem<T> nextElement)
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

        public QueueItem<T> NextElement 
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
