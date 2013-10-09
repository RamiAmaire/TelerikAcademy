using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    static void Main()
    {
        Person ceco = new Person("ceco", 5, "male");
        Type type = typeof (Person);
        object[] AllAttributes = type.GetCustomAttributes(false);
        foreach (var item in AllAttributes)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
