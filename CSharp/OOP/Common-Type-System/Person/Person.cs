using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Person
{
    private string name = null;
    private int? age = null;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int? Age
    {
        get { return age; }
        set { age = value; }
    }
    public Person(string name)
    {
        this.name = name;
    }
    public Person(string name, int? age)
        :this(name)
    {
        this.age = age;
    }
    public override string ToString()
    {
        Type t = this.GetType();
        string result = string.Format("Type : {0} \n Name : {1}",t, this.Name);
        if (this.age == null)
        {
            result += string.Format("\n Age : For this person age is not specified.");
            return result;
        }
        result += string.Format("\n Age : {0}",this.Age);
        return result;
    }
}
