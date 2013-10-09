using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Human
{
    private string firstName = null;
    private string lastName = null;
    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("First name must not be null or empty.");
                throw new FormatException("First name must not be null or empty.");
            }
            this.firstName = value;
        }
    }
    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Last name must not be null or empty.");
                throw new FormatException("Last name must not be null or empty.");
            }
            this.lastName = value;
        }
    }
    public Human()
    {
    }
    public Human(string firstname, string lastname)
    {
        this.firstName = firstname;
        this.lastName = lastname;
    }
}
