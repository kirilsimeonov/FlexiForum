using FlexiForum.Models.ForumViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Models.PostViewModels
{
    public class ListPostsModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string PostedOn { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }

        public int AuthorRating { get; set; }


        public int RepliesNumber { get; set;}

        public string ForumTitle { get; set;}

        public int ForumId { get; set;}

        public string ForumImage { get; set; }



        public ListForumsModel Forum { get; set;}

    }
}
