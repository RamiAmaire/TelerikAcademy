using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DepositAccout : Account, IDepositable, IWithdrawable
{
    public DepositAccout(Customer customer, double balance, double interestrate)
        : base(customer, balance, interestrate)
    {
    }
    public void Deposit(double item)
    {
        this.Balance += item;
    }
    public void Withdraw(double item)
    {
        this.Balance -= item;
        if (this.Balance < 0)
        {
            throw new ArgumentOutOfRangeException("You can't withdraw more money then you have.");
        }
    }
    public override double InterestAmount(int numberOfMonths)
    {
        double amount = 0;
        if (this.Balance > 0 && this.Balance > 1000)
        {
            amount = this.InterestRate * numberOfMonths;
        }
        return amount;
    } 
}
