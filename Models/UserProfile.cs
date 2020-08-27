using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models
{
    public class UserProfile
    {

        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string OldPassword { get; set; }
        public string ProfilePicture { get; set; } = "/upload/blank-person.png";

        public string ApplicationUserId { get; set; }

        //------------------------------------------------- //
        public string CIN { get; set; }

        public string AdressePostale { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }


        [DataType(DataType.Date)]
      //  [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Datedebut { get; set; }

        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datefin { get; set; }

        public string Ville { get; set; }
    }
}
