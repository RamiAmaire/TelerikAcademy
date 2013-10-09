using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Turtle : Animal
{
    public Turtle()
    {
    }
    public Turtle(string name, int age, Sex sex)
        :base(name,age,sex)
    {
    }
    public override void Sound()
    {
        Console.WriteLine("Turtle says nothing..., turtles never say anything");
    }
}
