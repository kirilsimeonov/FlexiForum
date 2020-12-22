using FlexiForum.Models.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Models.ForumViewModels
{
    public class ForumThemeModel
    {
        public string SearchText { get; set; }

        public IEnumerable<ListPostsModel> Posts { get; set;}

        public ListForumsModel Forum { get; set;}
    }
}
