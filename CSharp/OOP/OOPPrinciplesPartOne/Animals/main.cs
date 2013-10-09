using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    static void Main()
    {
        List<Dog> listOfDogs = new List<Dog>()
        {
            new Dog("pepi",3,Sex.Male),
            new Dog("gogi",5,Sex.Male),
            new Dog("penka",7,Sex.Female),
            new Dog("bonka",10,Sex.Female),
        };
        Console.WriteLine(listOfDogs.Average(x => x.Age));
        List<Kitten> listOfKittens = new List<Kitten>()
        {
            new Kitten("pussy",3,KittenSex.Female),
            new Kitten("gogi",10,KittenSex.Female),
            new Kitten("penka",7,KittenSex.Female),
            new Kitten("bonka",12,KittenSex.Female),
        };
        Console.WriteLine(listOfKittens.Average(x=>x.Age));
    }
}
