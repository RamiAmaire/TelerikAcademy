using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    public static Student[] FillArray(Student[] arr)
    {
        arr = new Student[arr.Length];
        Student pesho = new Student("Pesho", "Georgiev");
        Student gosho = new Student("Gosho", "Ivanov");
        Student ivan = new Student("Ivan", "Petkov");
        Student teodor = new Student("Teodor", "Angelov");
        Student angel = new Student("Angel", "Ivanov");
        arr[0] = pesho;
        arr[1] = gosho;
        arr[2] = ivan;
        arr[3] = teodor;
        arr[4] = angel;
        return arr;
    }
    public static dynamic SortArrayWithLINQ(Student[] arr)
    {
        var names =
            from name in arr
            where name.LastName.CompareTo(name.FirstName) > 0
            select name;
        return names;
    }
    static void Main()
    {
        Student[] arr = new Student[5];
        arr = FillArray(arr);
        dynamic sortedNames = SortArrayWithLINQ(arr);
        Console.WriteLine("Students which their first name is bigger alphabetically : ");
        foreach (var item in sortedNames)
        {
            Console.WriteLine(item.FirstName);
        }
    }
}
