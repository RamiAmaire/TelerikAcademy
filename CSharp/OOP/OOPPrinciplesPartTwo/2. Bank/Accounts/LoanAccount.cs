using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LoanAccount : Account, IDepositable
{
    public LoanAccount(Customer customer, double balance, double interestrate)
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
        if (type.Name == "Individual")
        {
            amount = this.InterestRate * (numberOfMonths - 3);
        }
        if (type.Name == "Company")
        {
            amount = this.InterestRate * (numberOfMonths - 2);
        }
        return amount;
    } 
}
