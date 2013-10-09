using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

public static class StringExtensionMethods
{
    public static string ToTitleCase(this string str)
    {
        string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        return titleCase;
    }
}
