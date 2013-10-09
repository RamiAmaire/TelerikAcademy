using System;
using System.Collections.Generic;
using System.Linq;

public class Testing
{
    public static void Main()
    {
        HashSet<Student> topStuds = new HashSet<Student>();
        topStuds.Add(new Student("Rami", 16, 21));
        topStuds.Add(new Student("Rida", 12, 18));
        topStuds.Add(new Student("Penko", 11, 17));
        topStuds.Add(new Student("Valyo", 10, 16));

        HashSet<Student> averageStuds = new HashSet<Student>();
        averageStuds.Add(new Student("Rami", 16, 21));
        averageStuds.Add(new Student("Velko", 10, 13));
        averageStuds.Add(new Student("Kircho", 5, 10));

        SortedSet<Student> allStuds = new SortedSet<Student>();
        allStuds.UnionWith(topStuds);
        allStuds.UnionWith(averageStuds);

        foreach (var stud in allStuds)
        {
            Console.WriteLine("Name {0}, Grade {1}, Age {2}", stud.Name, stud.Grade, stud.Age);
        }
    }
}
