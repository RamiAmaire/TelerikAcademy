using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    static void Main()
    {
        Customer pesho = new Company("Pesho", "Vankov");
        DepositAccout acc = new DepositAccout(pesho, 800, 10);
        acc.Withdraw(900);
    }
}
