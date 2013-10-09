using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Student : IComparable<Student>, ICloneable
{
    private string firstName = null;
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    private string midName = null;
    public string MidName
    {
        get { return midName; }
        set { midName = value; }
    }
    private string lastName = null;
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    private int ssn = 0;
    public int Ssn
    {
        get { return ssn; }
        set { ssn = value; }
    }
    private string permAddress = null;
    public string PermAddress
    {
        get { return permAddress; }
        set { permAddress = value; }
    }
    private int mobilePhone = 0;
    public int MobilePhone
    {
        get { return mobilePhone; }
        set { mobilePhone = value; }
    }
    private string eMail = null;
    public string EMail
    {
        get { return eMail; }
        set { eMail = value; }
    }
    private int course = 0;
    public int Course
    {
        get { return course; }
        set { course = value; }
    }
    private Specialty specialty = new Specialty();
    internal Specialty Specialty
    {
        get { return specialty; }
        set { specialty = value; }
    }
    private University university = new University();
    internal University University
    {
        get { return university; }
        set { university = value; }
    }
    private Faculty faculty = new Faculty();
    internal Faculty Faculty
    {
        get { return faculty; }
        set { faculty = value; }
    }
    public Student()
    {
    }
    public Student(string firstname, int ssn)
    {
        this.firstName = firstname;
        this.ssn = ssn;
    }
    public Student(string firstname, string midname, string lastname, int ssn, string permadress, int mobilephone,
        string email, int course, Specialty specialty, University university, Faculty faculty)
        :this(firstname,ssn)
    {
        this.midName = midname;
        this.lastName = lastname;
        this.permAddress = permadress;
        this.mobilePhone = mobilephone;
        this.eMail = email;
        this.course = course;
        this.university = university;
        this.specialty = specialty;
        this.faculty = faculty;
    }
    public override bool Equals(object obj)
    {
        Student other = obj as Student;
        if (other == null)
        {
            return false;
        }
        return this.FirstName == other.FirstName && this.MidName == other.MidName && this.LastName == other.LastName && this.Ssn == other.Ssn;
    }
    public static bool operator ==(Student stud1, Student stud2)
    {
        return stud1.Equals(stud2);
    }
    public static bool operator !=(Student stud1, Student stud2)
    {
        return !(stud1.Equals(stud2));
    }
    public override int GetHashCode()
    {
        return this.FirstName.GetHashCode() ^ this.MidName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.Ssn.GetHashCode()
            ^ this.PermAddress.GetHashCode() ^ this.MobilePhone.GetHashCode() ^ this.EMail.GetHashCode() ^ this.Course.GetHashCode()
            ^ this.Specialty.GetHashCode() ^ this.University.GetHashCode() ^ this.Faculty.GetHashCode();
    }
    public override string ToString()
    {
        Type t = this.GetType();
        string result = string.Format("Type : {0} \n First name : {1} \n Middle name : {2} \n Last name : {3}",t, this.FirstName, this.MidName, this.LastName);
        result += string.Format("\n SSN : {0} \n Permanent address : {1} \n Mobile phone : {2}", this.Ssn, this.PermAddress, this.MobilePhone);  
        result += string.Format("\n Email : {0} \n Course : {1} \n Specialty : {2}", this.EMail, this.Course, this.Specialty);
        result += string.Format("\n University : {0} \n Faculty : {1}", this.University, this.Faculty);
        return result;
    }
    public int CompareTo(Student other)
    {
        if (this.FirstName.Equals(other.FirstName))
        {
            return this.Ssn.CompareTo(other.Ssn);
        }
        return this.FirstName.CompareTo(other.FirstName);
    }
    public object Clone()
    {
        Student obj = new Student();
        obj.FirstName = this.FirstName;
        obj.MidName = this.MidName;
        obj.LastName = this.LastName;
        obj.Ssn = this.Ssn;
        obj.PermAddress = this.PermAddress;
        obj.MobilePhone = this.MobilePhone;
        obj.EMail = this.EMail;
        obj.Course = this.Course;
        obj.Specialty.Name = this.Specialty.Name; // cloning only non refental properties and strings (strings cannot be changed, so are valid in deep cloning)
        obj.University.Name = this.University.Name;
        obj.Faculty.Name = this.Faculty.Name;
        return obj;
    }
}
