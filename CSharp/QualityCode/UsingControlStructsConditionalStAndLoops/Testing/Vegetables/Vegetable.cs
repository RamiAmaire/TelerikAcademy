using System;

public abstract class Vegetable
{
    // Fields
    private double weight = 0;
    private decimal price = 0;
    private bool isPeeled = false;
    private bool isCut = false;
    private bool isRotten = false;

    // Contructor
    public Vegetable(double weight, decimal price)
    {
        this.Weight = weight;
        this.Price = price;
    }

    // Properties
    public double Weight
    {
        get
        {
            return this.weight;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Vegetable weight is out of range");
            }

            this.weight = value;
        }
    }

    public decimal Price
    {
        get
        {
            return this.price;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Vegetable price is out of range");
            }

            this.price = value;
        }
    }

    public bool IsPeeled
    {
        get
        {
            return this.isPeeled;
        }

        set
        {
            this.isPeeled = value;
        }
    }

    public bool IsCut
    {
        get
        {
            return this.isCut;
        }

        set
        {
            this.isCut = value;
        }
    }

    public bool IsRotten
    {
        get
        {
            return this.isRotten;
        }

        set
        {
            this.isRotten = value;
        }
    }
}
