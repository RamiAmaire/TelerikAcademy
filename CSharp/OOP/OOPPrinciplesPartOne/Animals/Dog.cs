using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Dog : Animal
{
    public Dog()
    {
    }
    public Dog(string name, int age, Sex sex)
        :base(name,age,sex)
    {
    }
    public override void Sound()
    {
        Console.WriteLine("Doggy says bau bau");
    }
}
