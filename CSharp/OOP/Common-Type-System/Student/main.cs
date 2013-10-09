using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    static void Main()
    {
        Student gosho = new Student("gosho",33);
        Student clonedGosho = gosho.Clone() as Student;
    }
}
