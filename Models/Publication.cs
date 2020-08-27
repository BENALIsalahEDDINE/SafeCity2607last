using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class Publication
    {
        [Key]
        public int id_pub { get; set; }
        [Required]
        public string id_source { get; set; }
        public int id_cq { get; internal set; }
        public int id_comment { get;  set; }
        public int publication { get;  set; }
        public int pho1 { get;  set; }
        public int pho2 { get;  set; }
        public int pho3 { get;  set; }
        public int ville { get;  set; }
        public int etat { get;  set; }
        public int explication { get;  set; }
        public int date { get;  set; }
        public int heure { get;  set; }
        public int secteur { get;  set; }
        public int rue { get;  set; }
        public int lati { get;  set; }
        public int longi { get;  set; }
    }
}
