using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class People : global::School, ILikable, IHateble
{
    private string peopleName = null;
    private int age = 0;
    private string sex = null;
    private List<ILikable> likeList = new List<ILikable>();
    private List<IHateble> hateList = new List<IHateble>();
    public string PeopleName
    {
        get { return this.peopleName; }
        set { this.peopleName = value; }
    }
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
    public string Sex
    {
        get { return this.sex; }
        set { this.sex = value; }
    }
    public List<ILikable> LikeList
    {
        get { return this.likeList; }
    }
    public List<IHateble> HateList
    {
        get { return this.hateList; }
    }
    public People(string peoplename, int age, string sex)
    {
        this.peopleName = peoplename;
        this.age = age;
        this.sex = sex;
    }
    public string GetName()
    {
        return this.peopleName;
    }
    public void Like(ILikable item)
    {
        likeList.Add(item);
    }
    public void Hate(IHateble item)
    {
        hateList.Add(item);
        
    }
    public void Likes()
    {
        foreach (var like in likeList)
        {
            Console.WriteLine(like.GetName() + " - " + like.GetType());
        }
    }
    public void Hates()
    {
        foreach (var hate in hateList)
        {
            Console.WriteLine(hate.GetName() + " - " + hate.GetType());
        }
    }
    public override string ToString()
    {
        string str = string.Format(this.peopleName + "\n" + this.age + "\n" + this.sex + "\n");
        return str;
    }
}

