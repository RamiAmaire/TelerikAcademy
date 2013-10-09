using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Customer
{
    private string firstName = null;
    private string lastName = null;
    private string address = null;
    private int telephone = 0;
    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }
    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }
    public string Address
    {
        get { return this.address; }
        set { this.address = value; }
    }
    public int Telephone
    {
        get { return this.telephone; }
        set { this.telephone = value; }
    }
    public Customer()
    {
    }
    public Customer(string firstname, string lastname)
    {
        this.firstName = firstname;
        this.lastName = lastname;
    }
    public Customer(string firstname, string lastname, string address, int telephone)
        :this(firstname,lastname)
    {
        this.address = address;
        this.telephone = telephone;
    }
    public override string ToString()
    {
        string result = string.Format("Firstname : " + this.FirstName + "\n" + "Lastname : " + this.LastName);
        return base.ToString();
    }
}
