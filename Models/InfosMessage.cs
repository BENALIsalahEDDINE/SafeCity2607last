using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class InfosMessage
    {
        [Key]
        public int PaymentReceiveId { get; set; }
        [Display(Name = "Payment Number")]
        public string PaymentReceiveName { get; set; }
        [Display(Name = "Message")]
        public int InvoiceId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        [Display(Name = "Payment Type")]
        public int PaymentTypeId { get; set; }
        public double PaymentAmount { get; set; }
        [Display(Name = "Full Payment")]
        public bool IsFullPayment { get; set; } = true;
    }
}
