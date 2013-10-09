using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Company : Customer
{
    public Company(string firstname, string lastname)
        : base(firstname, lastname)
    {
    }
    public Company(string firstname, string lastname, string address, int telephone)
        : base(firstname,lastname,address,telephone)
    {
    }
    
}
