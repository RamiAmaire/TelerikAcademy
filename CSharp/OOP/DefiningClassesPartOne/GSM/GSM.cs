using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSMAttributes
{
    class GSM
    {
        private string model = null;
        private string manufacturer = null;
        private int price = 0;
        private string owner = null;
        private Battery battery = new Battery();
        private Display display = new Display();
        private static GSM iPhone4S = new GSM();
        private Call call = new Call();
        private List<Call> callHistory = new List<Call>();
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }
        public int Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price must be 0 or bigger!");
                this.price = value;
            }
        }
        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
            set { iPhone4S = value; }
        }
        public Call Call
        {
            get { return this.call; }
            set { this.call = value; }
        }
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
        }
        public GSM()
        {
        }
        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }
        public GSM(string model, string manufacturer, Battery battery, Display display)
            : this(model, manufacturer)
        {
            this.battery = battery;
            this.Display = display;
        }
        public GSM(string model, string manufacturer, int price, string owner, Battery battery, Display display)
            : this(model, manufacturer, battery, display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
        }
        public override string ToString()
        {
            string info = string.Format("Model: " + this.model + "\n" + " Manufacturer: " + this.manufacturer + "\n" +
                " Price: " + this.price + "\n" + " Owner: " + this.owner + "\n" + " Battery model: " +
                this.battery.Model + "\n" + " Battery idletime: " + this.battery.Idletime + "\n" + " Battery hourstalk: " +
                this.battery.Hourstalk + "\n" + " Display size: " + this.Display.Size + "\n" + " Display colors: " + this.Display.Colors + "\n");
            return info;
        }
        public void PrintInfo()
        {
            Console.WriteLine(ToString());
        }
        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }
        public void RemoveCall(Call call)
        {
            this.callHistory.Remove(call);
        }
        public void RemoveAllCalls()
        {
            this.callHistory.Clear();
        }
        public string CalcTotalPrice(double price)
        {
            double sum = 0;
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                sum += callHistory[i].Duration * price;
            }
            string totalPrice = sum.ToString() + " $";
            return totalPrice;
        }
        public void CallInfo(Call call)
        {
            Console.WriteLine("Date : {0}", call.Date);
            Console.WriteLine("Start time : {0}", call.Time);
            Console.WriteLine("DialedPhoneNum : {0}", call.DialedPhoneNum);
            Console.WriteLine("Duration : {0}", call.Duration);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
        }
        public void RemoveLongestCall()
        {
            double maxDuration = 0;
            maxDuration = callHistory[0].Duration;
            int index = 0;
            for (int i = 1; i < callHistory.Count; i++)
            {
                if (maxDuration < callHistory[i].Duration)
                {
                    maxDuration = callHistory[i].Duration;
                    index = i;
                }
            }
            callHistory.RemoveAt(index);
        }
    }
}

