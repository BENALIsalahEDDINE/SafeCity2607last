using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class InfoPublicationControleurQ
    {
        [Key]
        public int GoodsReceivedNoteId { get; set; }
        [Display(Name = "GRN Number")]
        public string GoodsReceivedNoteName { get; set; }
        [Display(Name = "Purchase Order")]
        public int PurchaseOrderId { get; set; }
        [Display(Name = "GRN Date")]
        public DateTimeOffset GRNDate { get; set; }
        [Display(Name = "Vendor Delivery Order #")]
        public string VendorDONumber { get; set; }
        [Display(Name = "Vendor MessageControleurQualité / Message #")]
        public string VendorInvoiceNumber { get; set; }
        [Display(Name = "Lieu")]
        public int WarehouseId { get; set; }
        [Display(Name = "Full Receive")]
        public bool IsFullReceive { get; set; } = true;
    }
}
