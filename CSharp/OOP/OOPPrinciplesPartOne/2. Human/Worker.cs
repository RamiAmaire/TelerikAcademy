using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Worker : Human
{
    private double weekSalary = 0;
    private int workHoursPerDay = 0;
    public double WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Salary must be greater then 0");
                throw new ArgumentException("Salary must be greater then 0");
            }
            this.weekSalary = value;
        }
    }
    public int WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Work hours per day must be greater then 0");
                throw new ArgumentException("Work hours per day must be greater then 0");
            }
            this.workHoursPerDay = value;
        }
    }
    public Worker()
    {
    }
    public Worker(string firstname, string lastname, double weeksalary, int workhoursperday)
        :base(firstname,lastname)
    {
        this.weekSalary = weeksalary;
        this.workHoursPerDay = workhoursperday;
    }
    public double MoneyPerHour()
    {
        double moneyPerHour = this.weekSalary / (this.workHoursPerDay * 5); // if working five days a week
        return moneyPerHour;
    }
}
