using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSMAttributes
{
    class Call
    {
        private DateTime date;
        private string time = null;
        private int dialedPhoneNum = 0;
        private int duration = 0;
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        public string Time
        {
            get { return this.time; }
            set { this.time = value; }
        }
        public int DialedPhoneNum
        {
            get { return this.dialedPhoneNum; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Phone numbr!");
                }
                this.dialedPhoneNum = value;
            }
        }
        public int Duration
        {
            get { return this.duration; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid duration time!");
                }
                this.duration = value;
            }
        }
        public Call()
        {
        }
        public Call(int duration)
        {
            this.duration = duration;
        }
        public Call(DateTime date, string time, int dialedphonenumber, int duration)
            : this(duration)
        {
            this.date = date;
            this.time = time;
            this.dialedPhoneNum = dialedphonenumber;
        }
    }
}
