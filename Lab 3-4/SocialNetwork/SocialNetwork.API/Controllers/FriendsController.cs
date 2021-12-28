using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.DTO;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        [HttpGet(nameof(FindUsersByName))]
        public IActionResult FindUsersByName(string searchText)
        {
            string result = "Finding USERS: \n";
            try
            {
                foreach (var item in _friendsService.FindByName(searchText))
                {
                    result += $"Id{item.Id}: {item.SurName} {item.Name}\n";
                }
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetAllFriendRequestsToUser))]
        public IActionResult GetAllFriendRequestsToUser(int? userId)
        {
            string result = "All INPUT requests in friens: \n";
            try
            {
                foreach (var item in _friendsService.GetAllFriendRequestsToUser(userId))
                {
                    result += $"Request {{{item.Id}}}: {_friendsService.GetUserById(item.FromUser_Id)} --> {_friendsService.GetUserById(item.ToUser_Id)}\n";
                }
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetAllFriendRequestsFromUser))]
        public IActionResult GetAllFriendRequestsFromUser(int? userId)
        {
            string result = "All OUTPUT requests in friends: \n";
            try
            {
                foreach (var item in _friendsService.GetAllFriendRequestsFromUser(userId))
                {
                    result += $"Request {{{item.Id}}}: {_friendsService.GetUserById(item.FromUser_Id)} --> {_friendsService.GetUserById(item.ToUser_Id)}\n";
                }
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetAllFriends))]
        public IActionResult GetAllFriends(int? userId)
        {
            string result = "MY FRIENDS: \n";
            try
            {
                foreach (var item in _friendsService.GetAllRelationships(userId))
                {
                    result += $"{_friendsService.GetUserById(item.User2_Id)}\n";
                }
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetAllUsersInDB))]
        public IActionResult GetAllUsersInDB(int? userId)
        {
            string result = "ALL USERS in Social Network: \n";
            try
            {
                foreach (var item in _friendsService.GetAllUsersInDB(userId))
                {
                    result += $"Id{item.Id}: {_friendsService.GetUserById(item.Id)}\n";
                }
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return Ok(result);
        }

        /*[HttpGet(nameof(FindUsersByName))]
        public IActionResult FindUsersByName(string searchText)
        {
            string result = "Finding USERS: \n";
            try
            {
                foreach (var item in _friendsService.FindByName(searchText))
                {
                    result += $"Id{item.Id}: {item.SurName} {item.Name}\n";
                }
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return Ok(result);
        }*/

        [HttpPost(nameof(SendRequest))]
        public IActionResult SendRequest(int? from_userId, int? to_userId)
        {
            string result = "Request send succesfull!";
            try
            {
                _friendsService.SendRequest(from_userId, to_userId);
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }

        [HttpPost(nameof(AddNewChat))]
        public IActionResult AddNewChat(RelationshipsDTO relationships)
        {
            string result = "Chat was created succesfull!";
            try
            {
                _friendsService.AddNewChat(relationships);
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }

        [HttpPost(nameof(AddNewFriend))]
        public IActionResult AddNewFriend(int requestId)
        {
            string result = "";
            try
            {
                List<FriendRequestDTO> request = (List<FriendRequestDTO>)_friendsService.GetFriendRequestById(requestId);
                _friendsService.AddNewRelationships(requestId);
                result += $"Friend: {_friendsService.GetUserById(request[0].FromUser_Id)} was added in freiends User: {_friendsService.GetUserById(request[0].ToUser_Id)}  succesfull!";
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }


        [HttpDelete(nameof(DeleteFriendRequests))]
        public IActionResult DeleteFriendRequests(int request_id)
        {
            string result = $"Request with ID:{request_id} was deleted succesfull!";
            try
            {
                _friendsService.DeleteFriendRequests(request_id);
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }

        
    }
}
