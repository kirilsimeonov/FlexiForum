using FlexiForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlexiForum.Data.Interfaces
{
    public interface IPost
    {
        Post TakeById(int id);

        IEnumerable<Post> TakeSpecificPosts(string searchParameter); //search query

        IEnumerable<Post> TakeAll();

        IEnumerable<Post> TakeForumPosts(int id);


        Task Create(Post post);

        Task Delete(int id);

        //Task CreateReply(PostReply postReply);

        Task EditContent(int id, string newContent);
    }
}
 