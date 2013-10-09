using System;

/// <summary>
/// This class creates creatures, but it's beta
/// version and can create only humans and
/// depending on their age, makes them male or 
/// female.
/// </summary>
public class CreatureMashine
{
    public static Human MakeHuman(int age)
    {
        Human newHuman = new Human();
        newHuman.Age = age;

        if (age % 2 == 0)
        {
            newHuman.Name = "Man";
            newHuman.Sex = Sex.Male;
        }
        else
        {
            newHuman.Name = "Woman";
            newHuman.Sex = Sex.Female;
        }

        return newHuman;
    }
}