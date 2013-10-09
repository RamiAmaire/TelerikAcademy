using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    static void Main()
    {
        List<Student> studentsList = new List<Student>()
            {
                new Student("Pesho","Ivanov",3),
                new Student("Angel","Trifonov",1),
                new Student("Ceco","Hristov",7),
                new Student("Mladen","Georgiev",7),
                new Student("Hristo","Stoichkov",10),
                new Student("Dimitar","Berbatov",6),
                new Student("Frank","Lampard",9),
                new Student("Cristiano","Ronaldo",11),
                new Student("Lionel","Messi",11),
                new Student("Gundi","Shofiora",2),
            };
        studentsList = studentsList.OrderBy(grade => grade.Grade)
            .ThenBy(firstname => firstname.FirstName).ThenBy(lastname => lastname.LastName).ToList();
        Console.WriteLine("List of students sorted by grade : ");
        foreach (var student in studentsList)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName + " - " + student.Grade);
        }
        Console.WriteLine(new string('-',40));
        Console.WriteLine(new string('-', 40));
        List<Worker> workersList = new List<Worker>()
            {
                new Worker("Ivan","Angelov",1000,8),
                new Worker("Ceco","Dimitrov",400,8),
                new Worker("Kiro","Skalata",1200,8),
                new Worker("Liubo","Lejankata",700,6),
                new Worker("Mitio","Krika",1500,10),
                new Worker("Svetlin","Nakov",2000,8),
                new Worker("Nikolay","Kostov",2000,8),
                new Worker("Georgi","Georgiev",2000,8),
                new Worker("Doncho","Minkov",2000,8),
                new Worker("Barak","Obama",1000000,12),
            };
        workersList = workersList.OrderBy(s => s.MoneyPerHour())
            .ThenBy(n=>n.FirstName).ThenBy(n=>n.LastName).ToList();
        Console.WriteLine("List of workers sorted by money per hour : ");
        foreach (var worker in workersList)
        {
            Console.WriteLine(worker.FirstName + " " + worker.LastName + " - " + worker.MoneyPerHour() + "$");
        }
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(new string('-', 40));
        List<Human> peoplesList = new List<Human>();
        peoplesList.AddRange(studentsList);
        peoplesList.AddRange(workersList);
        peoplesList = peoplesList.OrderBy(n => n.FirstName).ThenBy(n=>n.LastName).ToList();
        Console.WriteLine("List of students and workers sorted by first and last name alphabetically");
        foreach (var person in peoplesList)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName + " - " + person.GetType());
        }
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(new string('-', 40));
    }
}
