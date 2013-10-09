﻿using System;

/// <summary>
/// This class makes an object - Chef.
/// The chef has name and restaurant as
/// properties.
/// A chef can also cook. 
/// He has implemented methods for
/// getting products and doing peeling,
///  cutting.
/// </summary>
public class Chef
{
    // Fields
    private string name = string.Empty;
    private string restaurant = string.Empty;

    // Constructor
    public Chef(string name, string restaurant)
    {
        this.Name = name;
        this.Restaurant = restaurant;
    }

    // Properties
    public string Name
    {
        get 
        {
            return this.name;
        }

        set 
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Chef name cannot be null.");
            }

            this.name = value; 
        }
    }

    public string Restaurant
    {
        get 
        { 
            return this.restaurant;
        }

        set 
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Restaurant name cannot be null.");
            }

            this.restaurant = value; 
        }
    }

    // Methods
    public void Cook()
    {
        // Getting vegetables
        Potato potato = this.GetPotato();
        Carrot carrot = this.GetCarrot();

        // Peeling the vegetables
        this.Peel(potato);
        this.Peel(carrot);

        // Cutting the vegetables
        this.Cut(potato);
        this.Cut(carrot);
        
        // Creating bowl
        Bowl bowl = this.GetBowl();
        
        // Adding the peeled and cut vegies
        // to the bowl
        bowl.AddVegetables(carrot);
        bowl.AddVegetables(potato);
    }

    private Carrot GetCarrot()
    {
        Carrot newCarrot = new Carrot(10, 5);
        return newCarrot;
    }

    private Potato GetPotato()
    {
        Potato newPotato = new Potato(200, 1);
        return newPotato;
    }

    private Bowl GetBowl()
    {
        Bowl newBowl = new Bowl();
        return newBowl;
    }

    private void Peel(Vegetable item)
    {
        item.IsPeeled = true;
    }

    private void Cut(Vegetable item)
    {
        item.IsCut = true;
    }
}
