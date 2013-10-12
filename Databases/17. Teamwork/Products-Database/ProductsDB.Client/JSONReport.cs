using System;
using System.Collections.Generic;

namespace ProductsDB.Client
{
    public class JSONReport
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string VendorName { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalIncome { get; set; }
    }
}
