using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Student
{
    private string firstName = null;
    private string lastName = null;
    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }
    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }
    public Student()
    {
    }
    public Student(string firstname, string lastname)
    {
        this.firstName = firstname;
        this.lastName = lastname;
    }
}
