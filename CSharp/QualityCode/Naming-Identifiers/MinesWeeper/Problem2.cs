public class Main
{
    public enum Sex
    {
        Male,
        Female
    }

    public void CreatePerson(int age)
    {
        Person person = new Person();
        person.Age = age;
        if (age % 2 == 0)
        {
            person.Name = "Батката";
            person.Sex = Sex.Male;
        }
        else
        {
            person.Name = "Мацето";
            person.Sex = Sex.Female;
        }
    }

    public class Person
    {
        public Sex Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
