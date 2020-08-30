using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class CommentairesdePublic
    {
        [Key]
        public int CommentaireId { get; set; }
        [Required]
        public string NomCommentaire { get; set; }
        public string Description { get; set; }
    }
}
