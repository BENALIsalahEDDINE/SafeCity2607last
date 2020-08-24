using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class SujetPublication
    {
        [Key]
        public int UnitOfMeasureId { get; set; }
        [Required]
        public string UnitOfMeasureName { get; set; }
        public string Description { get; set; }
    }
}
