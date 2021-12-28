using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.DTO;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.PL.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IFriendsService _friendsService;

        public RequestsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        public IActionResult Requests(UsersViewModel user)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<FriendRequestDTO, FriendViewModel>()).CreateMapper();
            var friendsTo = mapper.Map<IEnumerable<FriendRequestDTO>, List<FriendViewModel>>(_friendsService.GetAllFriendRequestsToUser(user.Id));
            var friendsFrom = mapper.Map<IEnumerable<FriendRequestDTO>, List<FriendViewModel>>(_friendsService.GetAllFriendRequestsFromUser(user.Id));

            ICollection<UsersViewModel> requestsTo = new List<UsersViewModel>();
            ICollection<UsersViewModel> requestsFrom = new List<UsersViewModel>();

            string result;
            try
            {
                foreach (var item in friendsTo)
                {
                    requestsTo.Add(new UsersViewModel
                    {
                        Id = item.Id,
                        Name = _friendsService.GetUserById(item.FromUser_Id),
                        SurName = _friendsService.GetUserById(item.ToUser_Id),
                    });
                }

                foreach (var item in friendsFrom)
                {
                    requestsFrom.Add(new UsersViewModel
                    {
                        Id = item.Id,
                        Name = _friendsService.GetUserById(item.FromUser_Id),
                        SurName = _friendsService.GetUserById(item.ToUser_Id),
                    });
                }
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return View("Requests", new UniversalUserViewModel { usersView = user, ienumToUsersView = requestsTo, ienumFromUsersView = requestsFrom });
        }


        /*[HttpGet]
        public IActionResult GetAllFriendRequestsToUser(UsersViewModel usersView)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<FriendRequestDTO, FriendViewModel>()).CreateMapper();
            var friends = mapper.Map<IEnumerable<FriendRequestDTO>, List<FriendViewModel>>(_friendsService.GetAllFriendRequestsToUser(usersView.Id));

            ICollection<UsersViewModel> name_f = new List<UsersViewModel>();

            string result;
            try
            {
                foreach (var item in friends)
                {
                    name_f.Add(new UsersViewModel
                    {
                        Id = item.Id,
                        Name = _friendsService.GetUserById(item.FromUser_Id),
                        SurName = _friendsService.GetUserById(item.ToUser_Id),
                    });
                }
                return View("Requests", name_f);
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return View("Requests");
        }*/

        /*[HttpGet(nameof(GetAllFriendRequestsFromUser))]
        public IActionResult GetAllFriendRequestsFromUser(UsersViewModel usersView)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<FriendRequestDTO, FriendViewModel>()).CreateMapper();
            var friends = mapper.Map<IEnumerable<FriendRequestDTO>, List<FriendViewModel>>(_friendsService.GetAllFriendRequestsFromUser(usersView.Id));

            ICollection<UsersViewModel> name_f = new List<UsersViewModel>();

            string result;
            try
            {
                foreach (var item in friends)
                {
                    name_f.Add(new UsersViewModel
                    {
                        Id = item.Id,
                        Name = _friendsService.GetUserById(item.FromUser_Id),
                        SurName = _friendsService.GetUserById(item.ToUser_Id),
                    });
                }
                return View("Requests", name_f);
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return View("Requests");
        }*/

        [HttpPost]
        public IActionResult AddNewFriend(UniversalUserViewModel model, UsersViewModel friend)
        {
            List<UsersViewModel> friendsTo = (List<UsersViewModel>)model.ienumToUsersView;
            List<UsersViewModel> friendsFrom = (List<UsersViewModel>)model.ienumToUsersView;

            if (friendsTo.Contains(friend)) friendsTo.Remove(friend);
            else if (friendsFrom.Contains(friend)) friendsFrom.Remove(friend);

            try
            {
                _friendsService.AddNewRelationships(friend.Id);
            }
            catch (ValidationException e)
            {

            }
            return View("Requests", new UniversalUserViewModel { usersView = model.usersView, ienumToUsersView = friendsTo, ienumFromUsersView = friendsFrom });
        }

        public IActionResult DeleteFriendRequests(UniversalUserViewModel model, UsersViewModel friend)
        {
            List<UsersViewModel> friendsTo = (List<UsersViewModel>)model.ienumToUsersView;
            List<UsersViewModel> friendsFrom = (List<UsersViewModel>)model.ienumToUsersView;

            if (friendsTo.Contains(friend)) friendsTo.Remove(friend);
            else if(friendsFrom.Contains(friend)) friendsFrom.Remove(friend);

            string result;
            try
            {
                _friendsService.DeleteFriendRequests(friend.Id);
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return View("Requests", new UniversalUserViewModel { usersView = model.usersView, ienumToUsersView = friendsTo, ienumFromUsersView = friendsFrom }) ;
        }
    }
}
