namespace ImplementingBiDictionary
{
    using System;

    public class Student: IComparable
    {
        public Student(string fName, string lName)
        {
            this.Fname = fName;
            this.Lname = lName;
        }

        public string Fname { get; set; }
        public string Lname { get; set; }

        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;

            unchecked
            {
                result = result * prime + this.Fname.GetHashCode();
                result = result * prime + this.Lname.GetHashCode();
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType().Name != "Student")
            {
                throw new ArgumentException("Invalid object.");
            }
            else
            {
                Student other = obj as Student;
                if (this.Fname == other.Fname)
                {
                    if (this.Lname == other.Lname)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public override string ToString()
        {
            string result = this.Fname + " " + this.Lname;
            return result;
        }

        public int CompareTo(object obj)
        {
            if (obj == null || obj.GetType().Name != "Student")
            {
                throw new ArgumentException("Invalid object.");
            }

            Student other = obj as Student;
            if (this.Lname == other.Lname)
            {
                if (this.Fname == other.Fname)
                {
                    return 0;
                }
                else
                {
                    return string.Compare(this.Fname, other.Fname);
                }
            }
            else
            {
                return string.Compare(this.Lname, other.Lname);
            }
        }
    }
}
