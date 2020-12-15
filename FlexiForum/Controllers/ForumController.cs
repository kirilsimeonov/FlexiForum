using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using FlexiForum.Models.ForumViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Controllers
{
    public class ForumController : Controller
    {


        private readonly IForum _forumService;


        public ForumController(IForum forumService)
        {

            _forumService = forumService;
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
