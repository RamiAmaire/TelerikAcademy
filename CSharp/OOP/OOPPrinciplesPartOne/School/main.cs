using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    static void Main()
    {
        School angl = new School("vtora angliiska", "sv troica");
        Teacher ivanov = new Teacher("ivanov",43,"Male");
        Student asq = new Student("Asq", 21, "Female", "316");
        Discipline biology = new Discipline("biology", 10, 5);
        asq.Like(biology);
        asq.Like(ivanov);
        asq.Likes();
        Console.WriteLine(asq.LikeList.Count());
        angl.SchoolAddStudent(asq);
        angl.SchoolAddTeacher(ivanov);
    }
}
