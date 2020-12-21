using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using FlexiForum.Models.PostViewModels;
using FlexiForum.Models.ReplyViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Controllers
{
    public class PostController : Controller
    {
        private static UserManager<ApplicationUser> _userManager; //provide the APis for interacting with users

        private readonly IForum _forumService;

        private readonly IPost _postService;


        public PostController(IPost postService, UserManager<ApplicationUser> userManager, IForum forumService)
        {
            _forumService = forumService;

            _userManager = userManager;

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
                ForumId=post.Forum.Id,
                ForumTitle=post.Forum.Title,
                CreatedOn = post.CreatedOn,
                AuthorName = post.User.UserName,
                AuthorId = post.User.Id,
                Content = post.Content,
                IsAdministrator= IsAdministrator(post.User),
                AuthorRating = post.User.Rating,
                AuthorPicture = post.User.ProfilePic,
                Replies=postReplies
                

            };


            return View(viewModel);
        }

        private  bool IsAdministrator(ApplicationUser user)
        {
            // var roles = await _userManager.GetRolesAsync(user.Id);
            //  var isAdmin = roles.Contains("Admin");
            //  return isAdmin;
            //return  _userManager.GetRolesAsync(user).Result.Contains("Admin"); //result blocks

           
            return User.IsInRole("Admin");
        }

        public IActionResult Create(int id) //forumId
        {
            var forum = _forumService.TakeById(id);

            var viewModel = new CreatePostModel
            {
                ForumId = forum.Id,

                ForumName = forum.Title,

                Author = User.Identity.Name, //claims principle, if were visiting the Create page we are gonna be the author

                ForumPicture = forum.Image
            };

            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostModel model) //Add post , submit post //ПРОВЕРИ ТУК
        {
            var userId = _userManager.GetUserId(User);  //build in userManager service

            var user =  _userManager.FindByIdAsync(userId).Result;

            var newPost = GeneratePost(model, user);

            _postService.Create(newPost).Wait(); //с Асинк не работи, за това добавих Wait,блок the thread until the task is complete

            return RedirectToAction("Index", "Post", new { id = newPost.Id });

            //TODO: Rating
        }

        private Post GeneratePost(CreatePostModel model, ApplicationUser user)
        {

            var forum = _forumService.TakeById(model.ForumId);

            var post = new Post
            {
                Content = model.Content,

                CreatedOn = DateTime.Now,
                Title = model.Title,
                User = user,
                Forum = forum
               
            };

            return post;
        }

        private IEnumerable<PostReplyModel> TakePostReplies(IEnumerable<PostReply> postReplies)
        {
            var results = postReplies.Select(x => new PostReplyModel 
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Content=x.Content,
                AuthorName =x.User.UserName,
                IsAdministrator=IsAdministrator(x.User),
                AuthorId=x.User.Id,
                AuthorRating = x.User.Rating,
                AuthorPicture = x.User.ProfilePic,
                
            });

            return results;
        }
    }
}
