using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ExtensionsForIEnumerable
{
    public static T Sum<T>(this IEnumerable<T> arr)
    {
        dynamic sum = 0;
        foreach (var item in arr)
        {
            sum += item;
        }
        return sum;
    }
    public static T Min<T>(this IEnumerable<T> arr)
    {
        dynamic min = long.MaxValue;
        foreach (var item in arr)
        {
            if (item < min)
            {
                min = item;
            }
        }
        return min;
    }
    public static T Max<T>(this IEnumerable<T> arr)
    {
        dynamic max = long.MinValue;
        foreach (var item in arr)
        {
            if (item > max)
            {
                max = item;
            }
        }
        return max;
    }
    public static T Average<T>(this IEnumerable<T> arr)
    {
        dynamic average = 0;
        dynamic sum = 0;
        foreach (var item in arr)
        {
            sum += item;
        }
        average = sum / arr.Count(x => x != null);
        return average;
    }
    public static T Product<T>(this IEnumerable<T> arr)
    {
        dynamic product = 0;
        foreach (var item in arr)
        {
            product *= item;
        }
        return product;
    }
}
