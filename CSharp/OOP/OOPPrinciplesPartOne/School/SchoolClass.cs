using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SchoolClass : global::School 
{
    private string classId = null;
    private List<Teacher> schoolClassTeachers = new List<Teacher>();
    private List<Student> schoolClassStudents = new List<Student>();
    public string ClassId
    {
        get { return this.classId; }
        set { this.classId = value; }
    }
    public List<Teacher> SchoolClassTeachers
    {
        get { return this.schoolClassTeachers; }
    }
    public List<Student> SchoolClassStudents
    {
        get { return this.schoolClassStudents; }
    }
    public SchoolClass(string classid, List<Teacher> schoolclassteachers)
    {
        this.classId = classid;
        this.schoolClassTeachers = schoolclassteachers;
    }
    public SchoolClass(string classid, List<Teacher> schoolclassteachers, List<Student> schoolclassstudents)
        : this(classid, schoolclassteachers)
    {
        this.schoolClassStudents = schoolclassstudents;
    }
    public void AddTeacher(Teacher item)
    {
        this.schoolClassTeachers.Add(item);
    }
    public void RemoveTeacher(Teacher item)
    {
        this.schoolClassTeachers.Remove(item);
    }
    public void RemoveAllTeachers()
    {
        this.schoolClassTeachers.Clear();
    }
    public void AddStudent(Student item)
    {
        this.schoolClassStudents.Add(item);
    }
    public void RemoveStudent(Student item)
    {
        this.schoolClassStudents.Remove(item);
    }
    public void RemoveAllStudents()
    {
        this.schoolClassStudents.Clear();
    }
    public override string ToString()
    {
        string str = string.Format("ClassId : " + classId + "\n" + "Number of teachers : " + this.schoolClassTeachers.Count + "\n" + "Number of students : " + this.schoolClassStudents.Count + "\n");
        return str;
    }
}
