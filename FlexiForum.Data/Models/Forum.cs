using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiForum.Data.Models
{
    public class Forum
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Info { get; set; }

        public string Image { get; set; }


        public IEnumerable<Post> Posts { get; set; }
    }
}
