using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Models.ReplyViewModels
{
    public class PostReplyModel
    {

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set;}

        public string AuthorName { get; set; }

        public bool IsAdministrator { get; set; }

        public string AuthorId { get; set; }
       
        public int AuthorRating { get; set; }

        public string AuthorPicture  { get; set; }

        public int PostId { get; set; }
        

    }
}
