using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using FlexiForum.Models.ForumViewModels;
using FlexiForum.Models.PostViewModels;
using FlexiForum.Models.SearchViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;

        public SearchController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult SearchResults(string searchText)
        {
            
            var posts = _postService.TakeSpecificPosts(searchText);
            var noResults = (!posts.Any() || !string.IsNullOrEmpty(searchText));
            var listedPosts = posts.Select(x => new ListPostsModel
            {
                Id = x.Id,
                Title = x.Title,
                PostedOn = x.CreatedOn.ToString(),
                AuthorRating = x.User.Rating,
                AuthorId = x.User.Id,
                Author = x.User.UserName,
                RepliesNumber = x.PostReplies.Count(),
                Forum = GenerateForum(x)


            });

            var searchModel = new SearchIndexModel
            {
                SearchText = searchText,
                Posts = listedPosts,
                NoSearchResults = noResults

            };

            return View();
        }

        private ListForumsModel GenerateForum(Post x)
        {
            var forum = x.Forum;
            return new ListForumsModel
            {
                Id = forum.Id,
                Info = forum.Info,
                Title=forum.Title,
                Picture=forum.Image
            
            };
        }

        [HttpPost]
        public IActionResult Search(string searchText)
        {
            return RedirectToAction("SearchResults", new { searchText});
        }
    }
}
