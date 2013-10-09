namespace Abstraction
{
    using System;

    /// <summary>
    ///     A template for making rectangles,
    ///     inheriting IFugre interface.
    /// </summary>
    /// <remarks>
    ///     Every rectangle has width and height and can
    ///     calculate it's perimeter and surface.
    /// </remarks>
    public class Rectangle : IFigure
    {
        // Fields
        private double width = 0;
        private double height = 0;

        // Constructor
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        // Properties
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0 || value > double.MaxValue)
                {
                    throw new ArgumentException(
                        "The width value is out of the appropriate range (0-)" + double.MaxValue + ")");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0 || value > double.MaxValue)
                {
                    throw new ArgumentException(
                        "The height value is out of the appropriate range (0-)" + double.MaxValue + ")");
                }

                this.height = value;
            }
        }

        // Methods
        public double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
