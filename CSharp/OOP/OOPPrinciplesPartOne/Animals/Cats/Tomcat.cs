using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Tomcat : Cat
{
    private TomcatSex sex = 0;
    public new TomcatSex Sex
    {
        get { return this.sex; }
        set
        {
            this.sex = value;
        }
    }
    public Tomcat()
    {
    }
    public Tomcat(string name, int age, TomcatSex sex)
    {
        this.Name = name;
        this.Age = age;
        this.sex = sex;
    }
    public override void Sound()
    {
        Console.WriteLine("Tomcat says waterMiauuu");
    }
}

