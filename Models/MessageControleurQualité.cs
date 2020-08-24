using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class MessageControleurQualité
    {
        [Key]
        public int BillId { get; set; }
        [Display(Name = "MessageControleurQualité / Message Number")]
        public string BillName { get; set; }
        [Display(Name = "GRN")]
        public int GoodsReceivedNoteId { get; set; }
        [Display(Name = "Vendor Delivery Order #")]
        public string VendorDONumber { get; set; }
        [Display(Name = "Vendor MessageControleurQualité / Message #")]
        public string VendorInvoiceNumber { get; set; }
        [Display(Name = "MessageControleurQualité Date")]
        public DateTimeOffset BillDate { get; set; }
        [Display(Name = "MessageControleurQualité Due Date")]
        public DateTimeOffset BillDueDate { get; set; }
        [Display(Name = "Type Proposition")]
        public int BillTypeId { get; set; }
    }
}
