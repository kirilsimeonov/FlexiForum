using FlexiForum.Data;
using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiForum.Services
{
    public class PostingService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> TakeAll()
        {
            throw new NotImplementedException();
        }

        public Post TakeById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> TakeForumPosts(int id)
        {
            var posts = _context.Forums.Where(x => x.Id == id).FirstOrDefault().Posts;

            return posts;
        }

        public IEnumerable<Post> TakeSpecificPosts(string searchParameter)
        {
            throw new NotImplementedException();
        }
    }
}
