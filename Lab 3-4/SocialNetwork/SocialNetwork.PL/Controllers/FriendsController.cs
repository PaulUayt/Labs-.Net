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
    public class FriendsController : Controller
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        public IActionResult Friends(UsersViewModel usersView)
        {
            return View("Friends", usersView);
        }

        [HttpGet]
        public IActionResult FindUsersByName(string searchText)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<UsersDTO, UsersViewModel>()).CreateMapper();
            var friends = mapper.Map<IEnumerable<UsersDTO>, List<UsersViewModel>>(_friendsService.FindByName(searchText));

            ICollection<UsersViewModel> name_f = new List<UsersViewModel>();

            string result;
            try
            {
                foreach (var item in friends)
                {
                    name_f.Add(new UsersViewModel
                    {
                        Id = item.Id,
                        Name = _friendsService.GetUserById(item.Id)
                    }) ;
                }
                return View("AddFriend", name_f);
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return View("AddFriend");
        }


        [HttpGet]
        public IActionResult GetAllFriends(UsersViewModel usersView)
        {
            ICollection<RelationshipsDTO> friendsDTOs = _friendsService.GetAllRelationships(usersView.Id);
            var mapper = new MapperConfiguration(config => config.CreateMap<RelationshipsDTO, RelationshipsViewModel>()).CreateMapper();
            var friends = mapper.Map<IEnumerable<RelationshipsDTO>, List<RelationshipsViewModel>>(friendsDTOs);

            ICollection<UsersViewModel> name_f = new List<UsersViewModel>();

            string result ;
            try
            {
                
                foreach (var item in friends)
                {
                    name_f.Add(new UsersViewModel
                    {
                        Name = _friendsService.GetUserById(item.User2_Id)
                    });
                }
                return View("My friends", name_f);
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return View("My friends");
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

        [HttpGet]
        public IActionResult Requests(UsersViewModel user)
        {
            return RedirectToAction("Requests", "Requests", user);
        }

        [HttpGet]
        public IActionResult AddFriend(UsersViewModel user)
        {
            return this.RedirectToAction("NewFriend", "NewFriend", user);
        }
    }
}
