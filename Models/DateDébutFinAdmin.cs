using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class DateDébutFinAdmin
    {
        [Key]
        public int SalesOrderId { get; set; }
        [Display(Name = "Order Number")]
        public string SalesOrderName { get; set; }
        [Display(Name = "Mission")]
        public int BranchId { get; set; }
        [Display(Name = "Admin")]
        public int CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }

        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }

        [Display(Name = "Admin Ref. Number")]
        public string CustomerRefNumber { get; set; }
        [Display(Name = "Sales Type")]
        public int SalesTypeId { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Freight { get; set; }
        public double Total { get; set; }
        public List<DateDébutFinAdminLine> DateDébutFinAdminLines { get; set; } = new List<DateDébutFinAdminLine>();
    }
}
