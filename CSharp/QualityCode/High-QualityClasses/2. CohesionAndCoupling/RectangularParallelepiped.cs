namespace CohesionAndCoupling
{
    using System;
    /// <summary>
    ///     A template for making rectangular parallelepiped.
    /// </summary>
    /// <remarks>
    ///     Every rectangular parallelepiped has width, height and depth.
    ///     It can calculate it's volume, 3D diagonal and 2D diagonals.
    /// </remarks>
    public class RectangularParallelepiped
    {
        private double width = 0;
        private double height = 0;
        private double depth = 0;

        public RectangularParallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
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

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value < 0 || value > double.MaxValue)
                {
                    throw new ArgumentException(
                        "The depth value is out of the appropriate range (0-)" + double.MaxValue + ")");
                }

                this.depth = value;
            }
        }

        // Methods
        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = GeometrylUtilities.CalcDistance3D(
                new Point3D(0, 0, 0),
                new Point3D(this.Width, this.Height, this.Depth));

            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = GeometrylUtilities.CalcDistance2D(
                new Point(0, 0),
                new Point(this.Width, this.Height));

            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = GeometrylUtilities.CalcDistance2D(
                new Point(0, 0),
                new Point(this.Width, this.Depth));

            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = GeometrylUtilities.CalcDistance2D(
                new Point(0, 0),
                new Point(this.Height, this.Depth));

            return distance;
        }
    }
}
