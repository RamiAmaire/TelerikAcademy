using System;

public class Student : IComparable
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public int Age { get; set; }

    public Student(string name, int grade, int age)
    {
        this.Name = name;
        this.Grade = grade;
        this.Age = age;
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType() || obj == null)
        {
            throw new ArgumentException("Invalid object or null");
        }
        else
        {
            Student otherStud = obj as Student;
            if (!this.Grade.Equals(otherStud.Grade))
            {
                return false;
            }

            if (!this.Name.Equals(otherStud.Name))
            {
                return false;
            }

            if (!this.Age.Equals(otherStud.Age))
            {
                return false;
            }

            return true;
        }
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.Name.GetHashCode();
            result = result * prime + this.Grade.GetHashCode();
            result = result * prime + this.Age.GetHashCode();
        }

        return result;
    }

    public int CompareTo(object obj)
    {
        if (obj.GetType() != this.GetType() || obj == null)
        {
            throw new ArgumentException("Invalid object");
        }
        else
        {
            Student otherStud = obj as Student;
            if (this.Grade == otherStud.Grade)
            {
                if (this.Name == otherStud.Name)
                {
                    if (this.Age == otherStud.Age)
                    {
                        return 0;
                    }
                    else
                    {
                        return this.Age.CompareTo(otherStud.Age);
                    }
                }
                else
                {
                    return string.Compare(this.Name, otherStud.Name);
                }
            }
            else
            {
                return this.Grade.CompareTo(otherStud.Grade);
            }
        }
    }
}

