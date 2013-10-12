using System;
using System.Collections.Generic;

namespace ProductsDB.Model
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
