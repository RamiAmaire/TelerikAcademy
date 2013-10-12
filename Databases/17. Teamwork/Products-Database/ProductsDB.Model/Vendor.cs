using System;
using System.Collections.Generic;

namespace ProductsDB.Model
{
    public class Vendor
    {
        private ICollection<Product> products;

        public Vendor()
        {
            this.products = new HashSet<Product>();
        }

        public int VendorId { get; set; }
        public string VendorName { get; set; }
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

        public override string ToString()
        {
            return this.VendorName;
        }
    }
}
