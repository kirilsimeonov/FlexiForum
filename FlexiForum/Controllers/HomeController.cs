using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using FlexiForum.Models;
using FlexiForum.Models.ForumViewModels;
using FlexiForum.Models.HomeViewModels;
using FlexiForum.Models.PostViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPost _postService;


        public HomeController(ILogger<HomeController> logger, IPost postService)
        {
            _logger = logger;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = CreateIndexHomeModel();

            return View(model);
        }

        private IndexHomeModel CreateIndexHomeModel()
        {
            var lastPosts = _postService.TakeLastPosts(10);

           

            var posts = lastPosts.Select(x => new ListPostsModel 
            {
                Id=x.Id,
                AuthorId = x.User.Id,
                Author = x.User.UserName,
                Title = x.Title,
                RepliesNumber = x.PostReplies.Count(),
                AuthorRating = x.User.Rating,
                PostedOn=x.CreatedOn.ToString(),
                Forum = GenerateForumForPost(x)
            });

            return new IndexHomeModel
            {
                LastPosts = posts,
                SearchQuery=""
                
            };
        }

        private ListForumsModel GenerateForumForPost(Post post)
        {
            var forum = post.Forum;

            var result = new ListForumsModel 
            {
                Id = forum.Id,
                Picture=forum.Image,
                Title = forum.Title,

            };

            return result;

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
