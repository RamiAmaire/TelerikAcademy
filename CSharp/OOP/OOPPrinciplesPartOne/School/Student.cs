using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Student : People
{
    private string classNumber = null;
    public string ClassNumber
    {
        get { return this.classNumber; }
        set { this.classNumber = value; }
    }
    public Student(string name, int age, string sex, string classnumber)
        :base(name,age,sex)
    {
        this.classNumber = classnumber;
    }
    public override string ToString()
    {
        return base.ToString() + this.classNumber;
    }
}
