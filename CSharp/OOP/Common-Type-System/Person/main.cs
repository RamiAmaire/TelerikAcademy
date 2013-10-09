using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    static void Main()
    {
        Person tom = new Person("Tom");
        Console.WriteLine(tom.ToString());
        Person josh = new Person("Josh", 20);
        Console.WriteLine(josh.ToString());
    }
}
