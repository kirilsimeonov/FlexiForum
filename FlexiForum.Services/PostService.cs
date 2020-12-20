using FlexiForum.Data;
using FlexiForum.Data.Interfaces;
using FlexiForum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiForum.Services
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Post post) //Add
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
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
            var post = _context.Posts.Where(x => x.Id == id).Include(x => x.User)
                
                .Include(x => x.PostReplies).ThenInclude(r=>r.User).Include(x => x.Forum).First(); //ползвам include понеже user e virtual и е lazyloaded

            return post; //взимам single post
        }

        public IEnumerable<Post> TakeForumPosts(int id)
        {
            var posts = _context.Forums.Where(x => x.Id == id).First().Posts;

            return posts;
        }

        public IEnumerable<Post> TakeSpecificPosts(string searchParameter)
        {
            throw new NotImplementedException();
        }
    }
}
