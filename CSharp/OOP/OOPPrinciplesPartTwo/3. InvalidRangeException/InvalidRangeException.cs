using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class InvalidRangeException<T> : ApplicationException
{
    private static int intMinRange = 0;
    private static int intMaxRange = 100;
    private static DateTime dateMinRange = new DateTime(1980, 1, 1);
    private static DateTime dateMaxRange = new DateTime(2013, 12, 31);
    public static int IntMinRange
    {
        get { return intMinRange; }
    }
    public static int IntMaxRange
    {
        get { return intMaxRange; }
    }
    public static DateTime DateMinRange
    {
        get { return dateMinRange; }
    }
    public static DateTime DateMaxRange
    {
        get { return dateMaxRange; }
    }
    public InvalidRangeException(string message, Exception innerexception)
        :base(message,innerexception)
    { 
    }
}
