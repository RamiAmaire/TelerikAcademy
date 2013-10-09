using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Frog : Animal
{
    public Frog()
    {
    }
    public Frog(string name, int age, Sex sex)
        :base(name,age,sex)
    {
    }
    public override void Sound()
    {
        Console.WriteLine("Frog says kwak kwak");
    }
}
