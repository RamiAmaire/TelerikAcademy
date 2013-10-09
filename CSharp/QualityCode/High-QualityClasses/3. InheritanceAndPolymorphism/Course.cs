namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     A template for making courses, consisting of:
    ///     the name of the course, the name of the teacher and
    ///     the students involved.
    /// </summary>
    public abstract class Course
    {
        // Fields
        private string courseName = string.Empty;
        private string teacherName = string.Empty;
        private IList<string> students = new List<string>();

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        // Properties
        public string CourseName 
        { 
            get
            {
                return this.courseName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course name cannot be null");   
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Teacher name cannot be null");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Students list cannot be null");
                }

                if (value.Count == 0)
                {
                    throw new ArgumentException("Students list must contain atleast one student");
                }

                this.students = value;
            }
        }

        // Methods
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.CourseName);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            result.Append(" }");

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
