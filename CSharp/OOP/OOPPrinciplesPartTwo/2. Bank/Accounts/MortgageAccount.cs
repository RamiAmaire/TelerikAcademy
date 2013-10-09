using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MortgageAccount : Account, IDepositable
{
    public MortgageAccount(Customer customer, double balance, double interestrate)
        : base(customer, balance, interestrate)
    {
    }
    public void Deposit(double item)
    {
        this.Balance += item;
    }
    public override double InterestAmount(int numberOfMonths)
    {
        Type type = this.Customer.GetType();
        double amount = 0;
        if (type.Name == "Company")
        {
            if (numberOfMonths <= 12)
            {
                amount = (this.InterestRate/2) * numberOfMonths;
            }
            else
            {
                amount = this.InterestRate * numberOfMonths;
            }   
        }
        if (type.Name == "Individual")
        {
            if (numberOfMonths <= 6)
            {
                amount = 0;
            }
            else
            {
                amount = this.InterestRate * numberOfMonths;
            }
        }
        return amount;
    } 
}
