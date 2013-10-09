using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Bowl
{
    // Fields
    private List<Vegetable> products;

    // Constructors
    public Bowl()
    {
        this.products = new List<Vegetable>();
    }

    // Methods
    public void AddVegetables(Vegetable item)
    {
        this.products.Add(item);
    }
}
