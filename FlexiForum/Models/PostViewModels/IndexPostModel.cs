using FlexiForum.Models.ReplyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Models.PostViewModels
{
    public class IndexPostModel
    {
        public int Id { get; set; }

        public string Title { get; set; }



        public int ForumId { get; set;}

        public string ForumTitle { get; set;}

        public string AuthorId { get; set; }

        public bool IsAdministrator { get; set; }

        public string AuthorName { get; set; }

        public int AuthorRating { get; set; }

        public string AuthorPicture { get; set; }

        public string Content { get; set;}

        public DateTime CreatedOn { get; set; }


        public IEnumerable<PostReplyModel> Replies { get; set;}

    }
}
