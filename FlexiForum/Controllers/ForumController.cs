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


        public ForumController(IForum forumService)
        {

            _forumService = forumService;
        }

        public IActionResult Theme(int id)
        {
            //var posts = _postService.TakeForumPosts(id);
            
            var forum = _forumService.TakeById(id);

            var posts = forum.Posts;


            var listedPosts = posts.Select(x => new ListPostsModel 
            {
                Id=x.Id,
                Title = x.Title,
                PostedOn=x.CreatedOn.ToString(),

                Forum = CreateForumList(x),

                RepliesNumber=x.PostReplies.Count(),
                AuthorRating = x.User.Rating,
                AuthorId=x.User.Id,



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

            var result = new ListForumsModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Info = forum.Info,
                Picture = forum.Image

            };
            return result;
        }

        private ListForumsModel CreateForumList(Forum forum)
        {
          

            var result = new ListForumsModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Info = forum.Info,
                Picture = forum.Image

            };
            return result;
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
