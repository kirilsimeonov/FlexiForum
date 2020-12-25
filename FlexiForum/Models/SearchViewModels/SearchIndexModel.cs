using FlexiForum.Models.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Models.SearchViewModels
{
    public class SearchIndexModel
    {
        public string SearchText;

        public IEnumerable<ListPostsModel> Posts { get; set; }

        public bool NoSearchResults { get; set;}

    }
}
