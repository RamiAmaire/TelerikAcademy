using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Version(2, 11)]
public class Person
{
    private string name = null;
    private int age = 0;
    private string sex = null;
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
    public Person(string name)
    {
        this.name = name;
    }
    public Person(string name, int age)
        : this(name)
    {
        this.age = 5;
    }
    public Person(string name, int age, string sex)
        : this(name, age)
    {
        this.sex = sex;
    }
}
