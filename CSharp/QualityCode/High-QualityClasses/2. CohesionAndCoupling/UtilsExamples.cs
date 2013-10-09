namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileHandlingUtilities.GetFileExtension("example"));
            Console.WriteLine(FileHandlingUtilities.GetFileExtension("example.pdf"));
            Console.WriteLine(FileHandlingUtilities.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileHandlingUtilities.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileHandlingUtilities.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileHandlingUtilities.GetFileNameWithoutExtension("example.new.pdf"));
            Console.WriteLine();

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                GeometrylUtilities.CalcDistance2D(
                new Point(1, -2),
                new Point(3, -4)));

            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                GeometrylUtilities.CalcDistance3D(
                new Point3D(1, 5, 9),
                new Point3D(2, -5, 9)));
            Console.WriteLine();

            RectangularParallelepiped rectParal = new RectangularParallelepiped(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", rectParal.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", rectParal.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", rectParal.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", rectParal.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", rectParal.CalcDiagonalYZ());
        }
    }
}
