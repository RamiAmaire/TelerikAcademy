using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Cat : Animal
{
    public Cat()
    {
    }
    public Cat(string name,int age, Sex sex)
        :base(name,age,sex)
    {
    }
    
}
