using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class School
{
    private string schoolName = null;
    private string location = null;
    private List<Student> schoolStudentsList = new List<Student>();
    private List<Teacher> schoolTeachersList = new List<Teacher>();
    private List<Discipline> schoolDisciplinesList = new List<Discipline>();
    private List<SchoolClass> schoolSchoolClassList = new List<SchoolClass>();
    public string SchoolName
    {
        get { return this.schoolName; }
        set { this.schoolName = value; }
    }
    public string Location
    {
        get { return this.location; }
        set { this.location = value; }
    }
    public List<Student> SchoolStudentsList
    {
        get { return this.schoolStudentsList; }
    }
    public List<Teacher> SchoolTeachersList
    {
        get { return this.schoolTeachersList; }
    }
    public List<Discipline> SchoolDisciplinesList
    {
        get { return this.schoolDisciplinesList; }
    }
    public List<SchoolClass> SchoolSchoolClassList
    {
        get { return this.schoolSchoolClassList; }
    }
    public School()
    {
    }
    public School(string schoolname, string location)
    {
        this.schoolName = schoolname;
        this.location = location;
    }
    public void SchoolAddDiscipline(Discipline item)
    {
        schoolDisciplinesList.Add(item);
    }
    public void SchoolRemoveDiscipline(Discipline item)
    {
        schoolDisciplinesList.Remove(item);
    }
    public void SchoolRemoveAllDisciplines()
    {
        schoolDisciplinesList.Clear();
    }
    public void SchoolAddTeacher(Teacher item)
    {
        this.schoolTeachersList.Add(item);
    }
    public void SchoolRemoveTeacher(Teacher item)
    {
        this.schoolTeachersList.Remove(item);
    }
    public void SchoolRemoveAllTeachers()
    {
        this.schoolTeachersList.Clear();
    }
    public void SchoolAddStudent(Student item)
    {
        this.schoolStudentsList.Add(item);
    }
    public void SchoolRemoveStudent(Student item)
    {
        this.schoolStudentsList.Remove(item);
    }
    public void SchoolRemoveAllStudents()
    {
        this.schoolStudentsList.Clear();
    }
    public void SchoolAddSchoolClass(SchoolClass item)
    {
        this.schoolSchoolClassList.Add(item);
    }
    public void SchoolRemoveSchoolClass(SchoolClass item)
    {
        this.schoolSchoolClassList.Remove(item);
    }
    public void SchoolRemoveAllSchoolClasses()
    {
        this.schoolSchoolClassList.Clear();
    }
}
