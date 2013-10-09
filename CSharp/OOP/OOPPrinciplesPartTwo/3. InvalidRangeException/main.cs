using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    
    static void Main() 
    {
        DateTime date = new DateTime(2012, 11, 23); // this date is in the range and will not cause exception
        date.InRange();
        int num = 200; // this int num isn't in the range 1-100 and will cause our exception
        num.InRange();
    }
}
