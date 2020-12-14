using FlexiForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlexiForum.Data.Interfaces
{
    public interface IForum
    {
        IEnumerable<Forum> TakeAll();

        IEnumerable<ApplicationUser> TakeAllActiveUsers();

        Forum TakeById(int id);


        Task Delete(int forumId);

        Task Create(Forum forum);

        Task UdpateForumTItle(int forumId, string newTitle);

        Task UdpateForumInfo(int forumId, string newInfo);
    }
}
