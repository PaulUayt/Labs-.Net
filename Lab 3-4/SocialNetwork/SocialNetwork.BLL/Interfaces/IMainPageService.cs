using SocialNetwork.BLL.DTO;
using System.Collections.Generic;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IMainPageService
    {
        int GetFriendsCount(int? userId);
        UsersDTO GetUserById(int userId);
        void Dispose();
    }
}
