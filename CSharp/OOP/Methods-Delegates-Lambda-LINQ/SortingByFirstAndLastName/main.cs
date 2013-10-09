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
        Student angelA = new Student("Angel", "Aleksandrov", 70);
        arr[0] = pesho;
        arr[1] = gosho;
        arr[2] = ivan;
        arr[3] = teodor;
        arr[4] = angel;
        arr[5] = angelA;
        return arr;
    }
    public static dynamic SortingWithLambda(Student[] arr)
    {
        dynamic students = arr.OrderByDescending(stud => stud.FirstName).ThenByDescending(stud => stud.LastName);
        
        return students;
    }
    public static dynamic SortingWithLINQ(Student[] arr)
    {
        var students =
            from stud in arr
            orderby stud.FirstName descending, stud.LastName descending
            select stud;
        return students;
    }
    static void Main()
    {
        Student[] arr = new Student[6];
        arr = FillArray(arr);
        //dynamic students = SortingWithLambda(arr);
        //foreach (var stud in students)
        //{
        //    Console.WriteLine(stud.FirstName + " " + stud.LastName);
        //}
        dynamic students = SortingWithLINQ(arr);
        foreach (var stud in students)
        {
            Console.WriteLine(stud.FirstName + " " + stud.LastName);
        }
    }
}
