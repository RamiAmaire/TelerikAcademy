using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSMAttributes
{
    class CallHistoryTest
    {
        static void Main()
        {
            GSM nokia = new GSM();

            nokia.AddCall(new Call(252));
            Call pesho = new Call((180));
            nokia.AddCall(pesho);

            nokia.CallInfo(new Call(252));
            nokia.CallInfo(pesho);

            string price = nokia.CalcTotalPrice(0.37);
            Console.WriteLine(price);

            nokia.RemoveLongestCall();
            price = nokia.CalcTotalPrice(0.37);
            Console.WriteLine(price);

            nokia.RemoveAllCalls();
            price = nokia.CalcTotalPrice(0.37);
            Console.WriteLine(price);
        }
    }
}
