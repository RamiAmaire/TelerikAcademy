using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Account : IInterestCalculatable
{
    private Customer customer = new Customer();
    private double balance = 0;
    private double interestRate = 0;
    public Customer Customer
    {
        get { return this.customer; }
        set { this.customer = value; }
    }
    public double Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }
    public double InterestRate
    {
        get { return this.interestRate; }
        set { this.interestRate = value; }
    }
    public Account()
    {
    }
    public Account(Customer customer, double balance, double interestrate)
    {
        this.customer = customer;
        this.balance = balance;
        this.interestRate = interestrate;
    }
    public abstract double InterestAmount(int numberOfMonths);
    public override string ToString()
    {
        string result = string.Format("Customer name : " + this.customer.LastName + "\n" + "Balance : " + this.balance + "\n" + "Interest rate : " + this.interestRate);
        return base.ToString();
    }
}
