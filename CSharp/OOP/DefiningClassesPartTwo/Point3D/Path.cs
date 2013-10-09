using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Path
{
    private List<Point3D> points = PathStorage.Points;
    public List<Point3D> Points
    {
        get { return this.points; }
    }
}
