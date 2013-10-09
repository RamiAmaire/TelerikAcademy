namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Inheriting Course, this class provides additional
    ///     information about the town where the course will be held.
    /// </summary>
    public class OffsiteCourse : Course
    {
        // Fields
        private string town = string.Empty;

        // Construcotrs
        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        // Properties
        public string Town 
        {
            get
            {
                return this.town;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Town cannot be null");
                }

                this.town = value;
            }
        }

        // Methods
        public override string ToString()
        {
            string str = base.ToString();
            str += "; Town = " + this.Town;
            return str;
        }
    }
}
