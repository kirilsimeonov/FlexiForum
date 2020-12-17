using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiForum.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string ProfilePic { get; set;}

        public bool MemberActive { get; set; }

        public DateTime ProfileCreatedOn { get; set;}

        public int Rating { get; set; }



    }
}
