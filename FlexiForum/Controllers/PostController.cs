using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using FlexiForum.Models.PostViewModels;
using FlexiForum.Models.ReplyViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;


        public PostController(IPost postService)
        {
            _postService = postService;
        }


        public IActionResult Index(int id)
        {
            var post = _postService.TakeById(id);

            var postReplies = TakePostReplies(post.PostReplies);

            var viewModel = new IndexPostModel
            {
                Id = post.Id,
                Title = post.Title,
                CreatedOn = post.CreatedOn,
                AuthorName = post.User.UserName,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                AuthorPicture = post.User.ProfilePic,
                Replies=postReplies
                

            };


            return View(viewModel);
        }

        private IEnumerable<PostReplyModel> TakePostReplies(IEnumerable<PostReply> postReplies)
        {
            var results = postReplies.Select(x => new PostReplyModel 
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Content=x.Content,
                AuthorName =x.User.UserName,
                AuthorId=x.User.Id,
                AuthorRating = x.User.Rating,
                AuthorPicture = x.User.ProfilePic,
                
            });

            return results;
        }
    }
}
