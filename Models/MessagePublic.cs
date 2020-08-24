using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class MessagePublic
    {
        [Key]
        public int ShipmentTypeId { get; set; }
        [Required]
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }
    }
}
