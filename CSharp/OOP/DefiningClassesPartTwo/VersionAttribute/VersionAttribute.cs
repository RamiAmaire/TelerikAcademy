using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Version : Attribute
{
    public int Major
    {
        get;
        set;
    }
    public int Minor
    {
        get;
        set;
    }
    public Version()
    {
    }
    public Version(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }
    public override string ToString()
    {
        string result = string.Format("Version: {0}.{1}", Major, Minor);
        return result;
    }
}
