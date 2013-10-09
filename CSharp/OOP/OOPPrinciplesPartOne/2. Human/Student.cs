using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Student : Human
{
    private int grade = 0;
    public int Grade
    {
        get { return this.grade; }
        set
        {
            if (value < 1)
            {
                Console.WriteLine("Grade must be 1 or greater.");
                throw new ArgumentException("Grade must be 1 or greater.");
            }
            this.grade = value;
        }
    }
    public Student()
    {
    }
    public Student(string firstname, string lastname, int grade)
        :base(firstname,lastname)
    {
        this.grade = grade;
    }
}
