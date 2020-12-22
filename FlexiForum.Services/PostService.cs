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
            var posts = _context.Posts.Include(x => x.User)

                .Include(x => x.PostReplies).ThenInclude(r => r.User).Include(x => x.Forum);

            return posts;
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

        public IEnumerable<Post> TakeLastPosts(int v)
        {
            var lastPosts = TakeAll().OrderByDescending(post => post.CreatedOn)
                .Take(v);

            return lastPosts;
        }

        public IEnumerable<Post> TakeSpecificPosts(Forum forum, string searchText)
        {
            

           

            if (string.IsNullOrEmpty(searchText))
            {
                return forum.Posts;
            }
            else
            {
                return forum.Posts.Where(x => x.Content.Contains(searchText) || x.Title.Contains(searchText));
            }

            
        }
    }
}
