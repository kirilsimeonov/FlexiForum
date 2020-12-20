using FlexiForum.Data;
using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiForum.Services
{
    public class ForumService : IForum
    {

        private readonly ApplicationDbContext _context;


        public ForumService(ApplicationDbContext context)
        {

            _context = context;
        }

        public IEnumerable<Forum> TakeAll()
        {
            return _context.Forums.Include(x => x.Posts); //инклудвам navigation property-то
        }
        public IEnumerable<ApplicationUser> TakeAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Forum TakeById(int id)
        {

            var forum = _context.Forums.Where(x => x.Id == id)
                .Include(x => x.Posts).ThenInclude(y => y.User)
                .Include(x => x.Posts).ThenInclude(y=>y.PostReplies).ThenInclude(r=>r.User)
                .FirstOrDefault();

            return forum;

        }

        public Task UdpateForumInfo(int forumId, string newInfo)
        {
            throw new NotImplementedException();
        }

        public Task UdpateForumTItle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

    }
}
