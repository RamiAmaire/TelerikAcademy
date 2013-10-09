using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSMAttributes
{
    class Display
    {
        private string size = null;
        private string colors = null;
        public string Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        public string Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }
        public Display()
        {
        }
        public Display(string size, string colors)
        {
            this.size = size;
            this.colors = colors;
        }
    }
}
