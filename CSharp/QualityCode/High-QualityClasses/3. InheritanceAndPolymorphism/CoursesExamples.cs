namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "C#",
                "Nakov",
                new List<string>() { "Thomas", "Ani", "Steve" },
                "Sofiq");

            LocalCourse localCourse = new LocalCourse(
                "C#",
                "Nakov",
                new List<string>() { "Gosho", "Pesho", "Rambo" },
                "light");

            Console.WriteLine(offsiteCourse.ToString());
            Console.WriteLine(localCourse.ToString());
        }
    }
}
