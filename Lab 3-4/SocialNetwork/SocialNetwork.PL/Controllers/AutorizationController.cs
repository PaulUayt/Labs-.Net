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
    public class AutorizationController : Controller
    {
        private readonly IAutorizationService _autorizationService;

        public AutorizationController(IAutorizationService autorizationService)
        {
            _autorizationService = autorizationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginUser(string email, string password)
        {
            string result = string.Empty;
          
            try
            {
                var user = _autorizationService.LogIn(email, password);
                UsersViewModel usersView = new UsersViewModel
                {
                    Id = user.Id,
                    SurName = user.SurName,
                    Name = user.Name,
                    Patronymic = user.Patronymic,
                    BirthdayCity = user.BirthdayCity,
                    Birthday = user.Birthday,
                    Email = user.Email,
                    Mobile = user.Mobile,
                    Password = user.Password
                };
                int id = user.Id;
                result = "Login successful!";
                return this.RedirectToAction("MainPage", "MainPage", new { id });
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            ViewBag.Result = result;
            return View("Autorization");
        }
    }
}

