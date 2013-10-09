namespace PrintingOrderedStudents
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Wintellect.PowerCollections;
    
    public class Demo
    {
        private static OrderedDictionary<string, SortedSet<Student>> SaveInput()
        {
            OrderedDictionary<string, SortedSet<Student>> input = new OrderedDictionary<string, SortedSet<Student>>();
            // just link the txt file from the project ->
            string path = @"C:\users\student\documents\visual studio 2012\Projects\[DSA] Data-Structures-Efficiency\1. PrintingOrderedStudents\students.txt";
            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null && line != string.Empty)
                {
                    string[] attribs = ParseLine(line);
                    Student newStud =  new Student(attribs[0], attribs[1]);
                    if (input.ContainsKey(attribs[2]))
                    {
                        input[attribs[2]].Add(newStud);
                    }
                    else
                    {
                        input[attribs[2]] = new SortedSet<Student>();
                        input[attribs[2]].Add(newStud);
                    }
                    
                    line = reader.ReadLine();
                }
            }

            return input;
        }

        private static string[] ParseLine(string line)
        {
            string[] attribs = line.Split(new string[]{"|"}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < attribs.Length; i++)
            {
                attribs[i] = attribs[i].Trim();
            }

            return attribs;
        }

        public static void Main()
        {
            OrderedDictionary<string, SortedSet<Student>> input = SaveInput();
            StringBuilder result = new StringBuilder();

            foreach (var course in input)
            {
                result.Append(course.Key + ": ");
                foreach (var stud in course.Value)
                {
                    result.Append(stud.ToString() + ", ");
                }

                result.AppendLine();
            }

            Console.WriteLine(result.ToString());
        }
    }
}
