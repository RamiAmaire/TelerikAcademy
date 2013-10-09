using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Distance
{
    public static double CalcDistance(Point3D pointOne, Point3D pointTwo)
    {
        double distance = (pointOne.X * pointTwo.X + pointOne.Y * pointTwo.Y + pointOne.Z * pointTwo.Z);
        distance = Math.Sqrt(distance);
        return distance;
    }
}
