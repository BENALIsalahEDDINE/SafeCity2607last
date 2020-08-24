using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class Message
    {
        [Key]
        public int InvoiceId { get; set; }
        [Display(Name = "Message Number")]
        public string InvoiceName { get; set; }
        [Display(Name = "Shipment")]
        public int ShipmentId { get; set; }
        [Display(Name = "Message Date")]
        public DateTimeOffset InvoiceDate { get; set; }
        [Display(Name = "Message Due Date")]
        public DateTimeOffset InvoiceDueDate { get; set; }
        [Display(Name = "Message Type")]
        public int InvoiceTypeId { get; set; }
    }
}
