namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    ///     Every point has horizontal(x) and vertiacl(y) value
    ///  </summary>
    /// <remarks>
    ///     I implement this class for better work with the
    ///     GeometrylUtilities methods and encapsulation.
    /// </remarks>
    public class Point
    {
        // Fields
        private double x = 0;
        private double y = 0;

        // Constructors
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        // Properties
        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value > double.MaxValue)
                {
                    throw new ArgumentException("X is out of range");
                }

                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value > double.MaxValue)
                {
                    throw new ArgumentException("Y is out of range");
                }

                this.y = value;
            }
        }
    }
}
