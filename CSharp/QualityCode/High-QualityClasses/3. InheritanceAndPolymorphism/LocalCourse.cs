namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Inheriting Course, this class provides additional
    ///     information about the lab where the course will be held.
    /// </summary>
    public class LocalCourse : Course
    {
        // Fields
        private string lab = string.Empty;

        // Construcotrs
        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        // Properties
        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Lab cannot be null");
                }

                this.lab = value;
            }
        }

        // Methods
        public override string ToString()
        {
            string str = base.ToString();
            str += "; Lab = " + this.Lab;
            return str;
        }
    }
}
