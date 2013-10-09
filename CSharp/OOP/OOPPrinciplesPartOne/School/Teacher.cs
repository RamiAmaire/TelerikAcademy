using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Teacher : People
{
    private List<Discipline> teacherDisciplines = new List<Discipline>();
    public List<Discipline> TeacherDisciplines
    {
        get { return this.teacherDisciplines; }
    }
    public Teacher(string name, int age, string sex)
        :base(name,age,sex)
    {
    }
    public void AddDiscipline(Discipline item)
    {
        teacherDisciplines.Add(item);
    }
    public void RemoveDiscipline(Discipline item)
    {
        teacherDisciplines.Remove(item);
    }
    public void RemoveAllDisciplines()
    {
        teacherDisciplines.Clear();
    }
    public override string ToString()
    {
        return base.ToString() + "Number of disciplines : " + teacherDisciplines.Count; 
    }
}
