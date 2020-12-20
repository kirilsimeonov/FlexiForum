using FlexiForum.Models.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Models.HomeViewModels
{
    public class IndexHomeModel
    {

        public IEnumerable<ListPostsModel> LastPosts { get; set; }

        public string SearchQuery { get; set; }

       

    }
}
