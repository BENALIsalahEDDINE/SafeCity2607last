using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class TypeMessage
    {
        [Key]
        public int InvoiceTypeId { get; set; }
        [Required]
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
    }
}
