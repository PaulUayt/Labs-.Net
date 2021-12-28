using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Interfaces;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.PL.Controllers;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.PL.Models;

namespace SocialNetwork.PL.Controllers
{
    public class MainPageController : Controller
    {
        private readonly IMainPageService _mainPageService;

        public MainPageController(IMainPageService mainPageService)
        {
            _mainPageService = mainPageService;
        }

        public IActionResult Main_Page()
        {
            return View("MainPage");
        }

        public IActionResult MainPage(int id)
        {
            string result;
            try
            {
                var user = _mainPageService.GetUserById(id);
                UsersViewModel usersViewModel = new UsersViewModel {
                    Id = user.Id,
                    SurName = user.SurName,
                    Name = user.Name,
                    Patronymic = user.Patronymic,
                    BirthdayCity = user.BirthdayCity,
                    Birthday = user.Birthday,
                    Email = user.Email,
                    Mobile = user.Mobile,
                    Password = user.Password,
                    RegistrationDate = user.RegistrationDate
                };
                ViewData.Add("Count", _mainPageService.GetFriendsCount(id).ToString());
                return View("MainPage",usersViewModel);
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            ViewBag.Result = result;
            return View("MainPage");
        }

        public IActionResult Main_p(UsersViewModel usersView)
        {
            return this.RedirectToAction("MainPage", "MainPage", new { usersView.Id });
        }

        public IActionResult Friends(UsersViewModel usersView)
        {
            return this.RedirectToAction("Friends", "Friends", usersView);
        }

        public IActionResult Chats(UsersViewModel usersView)
        {
            return this.RedirectToAction("GetAllFriends", "Chats", usersView);
        }

        [HttpGet]
        public RedirectResult Exit()
        {
            return Redirect("/Autorization/Index");
        }
    }
}
