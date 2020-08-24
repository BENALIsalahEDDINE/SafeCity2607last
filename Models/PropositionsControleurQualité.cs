using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class PropositionsControleurQualité
    {
        [Key]
        public int PurchaseTypeId { get; set; }
        [Required]
        public string PurchaseTypeName { get; set; }
        public string Description { get; set; }
    }
}
