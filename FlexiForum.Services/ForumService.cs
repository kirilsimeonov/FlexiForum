using FlexiForum.Data;
using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
