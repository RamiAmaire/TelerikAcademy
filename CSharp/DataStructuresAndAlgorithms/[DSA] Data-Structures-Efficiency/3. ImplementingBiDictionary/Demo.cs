namespace ImplementingBiDictionary
{
    using System;

    public class Demo
    {
        public static void Main()
        {
            BiDictionary<Student, Article, int> studentResults = new BiDictionary<Student, Article, int>(true);
            studentResults.Add(new Student("Gosho", "Petrov"), new Article("Telerik academy", 30, "Nakov", 30 % 5), 5);
        }
    }
}
