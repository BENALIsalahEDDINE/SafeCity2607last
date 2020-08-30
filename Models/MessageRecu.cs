using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class MessageRecu
    {
        [Key]
        public int Id_Mes { get; set; }
        [Required]
        public int Id_Source { get; set; }
        public int Id_Com { get; set; }
        public string Messagee { get; set; }
        public string Ville { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTime Heure { get; set; }
    }
}
