namespace FillLabyrinth
{
    using System;

    public class Direction
    {
        public Direction(int top, int left)
        {
            this.Top = top;
            this.Left = left;
        }

        public int Top { get; set; }
        public int Left { get; set; }
    }
}

