class Student
{
    private string firstName = null;
    private string lastName = null;
    private int age = 0;
    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }
    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
    public Student()
    {
    }
    public Student(string firstname, string lastname)
    {
        this.firstName = firstname;
        this.lastName = lastname;
    }
    public Student(string firstname, string lastname, int age)
        : this(firstname, lastname)
    {
        this.age = age;
    }
}