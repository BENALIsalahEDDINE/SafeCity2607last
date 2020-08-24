using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class Lieu
    {
        [Key]
        public int WarehouseId { get; set; }
        [Required]
        public string WarehouseName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Mission")]
        public int BranchId { get; set; }
    }
}
