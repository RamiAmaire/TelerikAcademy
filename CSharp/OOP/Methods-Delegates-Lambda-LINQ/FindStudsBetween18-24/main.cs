using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    public static Student[] FillArray(Student[] arr)
    {
        arr = new Student[arr.Length];
        Student pesho = new Student("Pesho", "Georgiev", 25);
        Student gosho = new Student("Gosho", "Ivanov", 21);
        Student ivan = new Student("Ivan", "Petkov", 33);
        Student teodor = new Student("Teodor", "Angelov", 18);
        Student angel = new Student("Angel", "Ivanov", 70);
        arr[0] = pesho;
        arr[1] = gosho;
        arr[2] = ivan;
        arr[3] = teodor;
        arr[4] = angel;
        return arr;
    }
    static void Main()
    {
        Student[] arr = new Student[5];
        arr = FillArray(arr);
        var names =
            from name in arr
            where name.Age >= 18 && name.Age <= 24
            select name;
        Console.WriteLine("Students from 18 to 24 years old : ");
        foreach (var student in names)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }
}
