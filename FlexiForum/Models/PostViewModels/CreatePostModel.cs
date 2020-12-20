using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Models.PostViewModels
{
    public class CreatePostModel
    {

       // public int Id { get; set; }
        public string Author { get; set; }

       public string Title { get; set; }
        public string ForumName { get; set; }

        public int ForumId { get; set; }

        public string ForumPicture { get; set; }

        public string Content { get; set;}
    }
}
