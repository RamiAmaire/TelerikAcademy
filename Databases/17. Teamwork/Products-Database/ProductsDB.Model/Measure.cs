using System;
using System.Collections.Generic;

namespace ProductsDB.Model
{
    public class Measure
    {
        private ICollection<Product> products;

        public Measure()
        {
            this.products = new HashSet<Product>();
        }

        public int MeasureId { get; set; }
        public string MeasureName { get; set; }
        public virtual ICollection<Product> Prodcuts
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }
    }
}
