﻿using FlexiForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlexiForum.Data.Interfaces
{
    public interface IPost
    {
        Post TakeById(int id);

        IEnumerable<Post> TakeSpecificPosts(string searchParameter);

        IEnumerable<Post> TakeAll();

        Task Create(Post post);

        Task Delete(int id);

        //Task CreateReply(PostReply postReply);

        Task EditContent(int id, string newContent);
    }
}
 