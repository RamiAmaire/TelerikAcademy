using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Discipline : global::School, ILikable, IHateble
{
    private string disciplineName = null;
    private int numberOfLectures = 0;
    private int numberOfExercises = 0;
    public string DisciplineName
    {
        get { return this.disciplineName; }
        set { this.disciplineName = value; }
    }
    public int NumberOfLectures
    {
        get { return this.numberOfLectures; }
        set { this.numberOfLectures = value; }
    }
    public int NumberOfExercises
    {
        get { return this.numberOfExercises; }
        set { this.numberOfExercises = value; }
    }
    public Discipline(string disciplinename, int numberoflectures, int numberofexercises)
    {
        this.disciplineName = disciplinename;
        this.numberOfLectures = numberoflectures;
        this.numberOfExercises = numberofexercises;
    }
    public string GetName()
    {
        return this.disciplineName;
    }
    public override string ToString()
    {
        string str = string.Format(this.disciplineName + "\n" + this.numberOfLectures + "\n" + this.numberOfExercises);
        return str;
    }

    string ILikable.GetName()
    {
        throw new NotImplementedException();
    }
}
