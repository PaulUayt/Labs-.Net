using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.PL.Controllers
{
    public class NewFriendController : Controller
    {
        private readonly IFriendsService _friendsService;

        public NewFriendController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        public IActionResult NewFriend(UsersViewModel user)
        {
            return View("NewFriend", user);
        }

        [HttpGet(nameof(GetAllUsersInDB))]
        public IActionResult GetAllUsersInDB(UsersViewModel user)
        {
            string result = "ALL USERS in Social Network: \n";
            try
            {
                foreach (var item in _friendsService.GetAllUsersInDB(user.Id))
                {
                    result += $"Id{item.Id}: {_friendsService.GetUserById(item.Id)}\n";
                }
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return View(result);
        }
    }
}
