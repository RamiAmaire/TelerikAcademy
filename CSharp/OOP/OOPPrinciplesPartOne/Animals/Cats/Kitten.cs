using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Kitten : Cat
{
    private KittenSex sex = 0;
     
    public new KittenSex Sex
    {
        get { return this.sex; }
        set
        {
            this.sex = value;
        }
    }
    public Kitten()
    {
    }
    public Kitten(string name, int age, KittenSex sex)
    {
        this.Name = name;
        this.Age = age;
        this.sex = sex;
    }
    public override void Sound()
    {
        Console.WriteLine("Kitten says Miauuu");
    }
}
