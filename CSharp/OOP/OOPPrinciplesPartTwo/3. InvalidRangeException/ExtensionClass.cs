using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class ExtensionClass
{
    public static void InRange(this int item)
    {
        int value = item;
        if (value < InvalidRangeException<int>.IntMinRange || value > InvalidRangeException<int>.IntMaxRange)
        {
            string message = string.Format("In this project int must be {0} - {1}", InvalidRangeException<int>.IntMinRange, InvalidRangeException<int>.IntMaxRange);
            throw new InvalidRangeException<int>(message, new ArgumentOutOfRangeException());
        }
    }
    public static void InRange(this DateTime item)
    {
        DateTime value = item;
        if (value < InvalidRangeException<DateTime>.DateMinRange || value > InvalidRangeException<DateTime>.DateMaxRange)
        {
            string message = string.Format("In this project dates must be {0} - {1}", InvalidRangeException<int>.DateMinRange, InvalidRangeException<int>.DateMaxRange);
            throw new InvalidRangeException<int>(message, new ArgumentOutOfRangeException());
        }
    }
}
