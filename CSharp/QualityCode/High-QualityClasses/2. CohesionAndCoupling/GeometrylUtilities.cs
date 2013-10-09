namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    ///     This class is utility class for geometry calculations.
    ///     It has 2 methods, calculating the distance between two 2D
    ///     points and two 3D points.
    /// </summary>
    public static class GeometrylUtilities
    {
        public static double CalcDistance2D(Point pointOne, Point pointTwo)
        {
            if (pointOne == null)
            {
                throw new ArgumentNullException("Point one cannot be null");
            }

            if (pointTwo == null)
            {
                throw new ArgumentNullException("Point two cannot be null");
            }

            double widthDistance = (pointTwo.X - pointOne.X) * (pointTwo.X - pointOne.X);
            double heightDistance = (pointTwo.Y - pointOne.Y) * (pointTwo.Y - pointOne.Y);

            double distance = widthDistance + heightDistance;
            distance = Math.Sqrt(distance);

            return distance;
        }

        public static double CalcDistance3D(Point3D pointOne, Point3D pointTwo)
        {
            if (pointOne == null)
            {
                throw new ArgumentNullException("Point one cannot be null");
            }

            if (pointTwo == null)
            {
                throw new ArgumentNullException("Point two cannot be null");
            }

            double widthDistance = (pointTwo.X - pointOne.X) * (pointTwo.X - pointOne.X);
            double heightDistance = (pointTwo.Y - pointOne.Y) * (pointTwo.Y - pointOne.Y);
            double depthDistance = (pointTwo.Z - pointOne.Z) * (pointTwo.Z - pointOne.Z);

            double distance = widthDistance + heightDistance + depthDistance;
            distance = Math.Sqrt(distance);
            return distance;
        }
    }
}
