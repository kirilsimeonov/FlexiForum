using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiForum.Data.Models
{
    public class PostReply
    {
        public int Id { get; set;}

        public DateTime CreatedOn { get; set; }

        public string Content { get; set;}

        public virtual Post Post { get; set; }

        public virtual ApplicationUser User { get; set;}
    }
}
