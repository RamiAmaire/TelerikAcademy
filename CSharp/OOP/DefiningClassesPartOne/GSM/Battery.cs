using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSMAttributes
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }
    class Battery
    {
        private string model = null;
        private int idletime = 0;
        private int hourstalk = 0;
        private BatteryType type = 0;
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Idletime
        {
            get { return this.idletime; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Idletime must be 0 or bigger!");
                this.idletime = value;
            }
        }
        public int Hourstalk
        {
            get { return this.hourstalk; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Hourstalk must be 0 or bigger!");
                this.hourstalk = value;
            }
        }
        public BatteryType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public Battery()
        {
        }
        public Battery(string model, int idletime, int hourstalk, BatteryType type)
        {
            this.model = model;
            this.idletime = idletime;
            this.hourstalk = hourstalk;
            this.type = type;
        }
    }
}
