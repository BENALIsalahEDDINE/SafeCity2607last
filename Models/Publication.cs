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
        public int id_source { get; set; }
        public int id_cq { get; internal set; }
        public int id_comment { get;  set; }
        public string publication { get;  set; }
        public string pho1 { get;  set; }
        public string pho2 { get;  set; }
        public string pho3 { get;  set; }
        public string ville { get;  set; }
        public string etat { get;  set; }
        public string explication { get;  set; }
        public DateTimeOffset date { get;  set; }
        public DateTime heure { get;  set; }
        public string secteur { get;  set; }
        public string rue { get;  set; }
        public int lati { get;  set; }
        public int longi { get;  set; }
    }
}
