using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Animal : ISound
{
    private string name = null;
    private int age = 0;
    private Sex sex = 0;
    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Animal's name must not be null or empty.");
                throw new Exception();
            }
            this.name = value;
        }
    }
    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Animal's age must be 1 or greater.");
                throw new Exception();
            }
            this.age = value;
        }
    }
    public Sex Sex
    {
        get { return this.sex; }
        set
        {
            this.sex = value;
        }
    }
    public Animal()
    {
    }
    public Animal(string name, int age, Sex sex)
    {
        this.name = name;
        this.age = age;
        this.sex = sex;
    }
    public abstract void Sound();
}
