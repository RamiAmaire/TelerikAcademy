using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//either this or callhistorytest because we can't have two main methods
//namespace GSMAttributes
//{
//    class GSMTest
//    {
//        static void Main()
//        {
//            GSM.IPhone4S = new GSM("IPhone4S", "Apple", 1300, "Gates", new Battery("tooStrong", 5, 3, BatteryType.NiCd),
//                new Display("16x9", "Black and yellow"));
//            GSM Samsung = new GSM("Galaxy S IV", "Samsung", 1000, "Gosho", new Battery(), new Display());
//            List<GSM> phones = new List<GSM>();
//            phones.Add(Samsung);
//            foreach (var gsm in phones)
//            {
//                gsm.PrintInfo();
//            }
//            GSM.IPhone4S.PrintInfo();
//        }
//    }
//}