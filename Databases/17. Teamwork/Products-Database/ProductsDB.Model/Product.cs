using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsDB.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }
        public string ProductName { get; set; }
        public Decimal BasePrice { get; set; }
    }
}
