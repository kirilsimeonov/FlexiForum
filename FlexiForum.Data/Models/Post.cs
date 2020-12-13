using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiForum.Data.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }


        public virtual ApplicationUser User { get; set; }

        public virtual Forum Forum { get; set; }

        public virtual IEnumerable<PostReply> PostReplies { get; set; }
    }
}
