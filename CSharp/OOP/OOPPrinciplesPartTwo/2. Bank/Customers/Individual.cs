using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Individual : Customer
{
    private int age = 0;
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
    public Individual(string firstname, string lastname, int age)
        : base(firstname, lastname)
    {
        this.age = age;
    }
    public Individual(string firstname, string lastname, int age, string address, int telephone)
        : base(firstname, lastname, address, telephone)
    {
        this.age = age;
    }
    public override string ToString()
    {
        string result = string.Format("Firstname : " + this.FirstName + "\n" + "Lastname : " + this.LastName + "Age : " + this.Age);
        return base.ToString();
    }
}
