using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Point3D
{
    private int x;
    private int y;
    private int z;
    public static readonly Point3D zero = new Point3D(0, 0, 0);
    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }
    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }
    public int Z
    {
        get { return this.z; }
        set { this.z = value; }
    }
    public static Point3D Zero
    {
        get { return zero; }
    }
    public Point3D()
    {
    }
    public Point3D(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public override string ToString()
    {
        string pointToString = string.Format("Height= {0}" + "\n" + "Width= {1} " + "\n" + "Depth= {2}", x, y, z);
        return pointToString;
    }
}
