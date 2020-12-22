using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using FlexiForum.Models.ForumViewModels;
using FlexiForum.Models.PostViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Controllers
{
    public class ForumController : Controller
    {

        private readonly IPost _postService;

        private readonly IForum _forumService;


        public ForumController(IForum forumService, IPost postService)
        {
            _postService = postService;
            _forumService = forumService;

        }
        [HttpPost]
        public IActionResult Search(int id,string searchText)
        {
            return RedirectToAction("Theme", new { id, searchText });
        }

        public IActionResult Theme(int id, string searchText)
        {
            var posts = new List<Post>();
            
            var forum = _forumService.TakeById(id);

          
                posts = _postService.TakeSpecificPosts(forum, searchText).ToList();
            
            


            var listedPosts = posts.Select(x => new ListPostsModel 
            {
                Id=x.Id,
                Title = x.Title,
                AuthorId = x.User.Id,
                RepliesNumber = x.PostReplies.Count(),
                AuthorRating = x.User.Rating,
                Author = x.User.UserName,
                
                PostedOn=x.CreatedOn.ToString(),
                
                
                

                Forum = CreateForumList(x)
            });

            var model = new ForumThemeModel
            {
                Posts=listedPosts,
                Forum = CreateForumList(forum)
            };

            return View(model);
        }

        private ListForumsModel CreateForumList(Post post)
        {
            var forum = post.Forum;

            return CreateForumList(forum);


          /*  return new ListForumsModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Info = forum.Info,
                Picture = forum.Image

            };
            */
        }

        private ListForumsModel CreateForumList(Forum forum)
        {
          

            return new ListForumsModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Info = forum.Info,
                Picture = forum.Image

            };
            
        }

        public IActionResult Index()
        {

            IEnumerable<ListForumsModel> forums = _forumService.TakeAll().Select(x=> new ListForumsModel 
            {
            Id= x.Id,
            Title = x.Title,
            Info = x.Info
            }
            );

            var model = new IndexForumModel
            {
                ForumsList = forums
            };
            return View(model);
        }
    }
}
