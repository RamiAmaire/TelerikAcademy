namespace Abstraction
{
    using System;

    /// <summary>
    ///     A template for making circles,
    ///     inheriting IFugre interface.
    /// </summary>
    /// <remarks>
    ///     Every circle has radius and can
    ///     calculate it's perimeter and surface.
    /// </remarks>
    public class Circle : IFigure
    {
        // Fields
        private double radius = 0;
        
        // Constructors
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        // Properties
        public double Radius 
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value < 0 || value > double.MaxValue)
                {
                    throw new ArgumentException(
                        "The radius value is out of the appropriate range (0-)" + double.MaxValue + ")");
                }

                this.radius = value;
            }
        }

        public double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
