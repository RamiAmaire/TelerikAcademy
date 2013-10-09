namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    ///     Every 3d point has horizontal(x), vertiacl(y) and
    ///     depth(z) value.
    ///  </summary>
    /// <remarks>
    ///     I implement this class for better work with the
    ///     GeometrylUtilities methods and encapsulation.
    /// </remarks>
    public class Point3D : Point
    {
        // Fields 
        private double z = 0;

        // Constructors
        public Point3D(double x, double y, double z)
            : base(x, y)
        {
            this.Z = z;
        }

        // Properties
        public double Z
        {
            get
            {
                return this.z;
            }

            set
            {
                if (value > double.MaxValue)
                {
                    throw new ArgumentException("Z is out of range");
                }

                this.z = value;
            }
        }
    }
}
