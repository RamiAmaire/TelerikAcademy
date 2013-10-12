using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsDB.Model
{
    public class SalesReport
    {
        public int SalesReportId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
