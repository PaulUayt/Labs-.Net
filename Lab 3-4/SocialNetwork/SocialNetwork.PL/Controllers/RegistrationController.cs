using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.DTO;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.PL.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public IActionResult Registration() 
        {
            return View("Registration");
        }

        [HttpPost]
        public IActionResult RegisterUser(string surName, string name,
            string patronymic, string birthdayCity, string birthday,
            string password, string email, string mobile)
        {
            string result = "User was created successful";
            UsersDTO user = new UsersDTO
            {
                SurName = surName,
                Name = name,
                Patronymic = patronymic,
                BirthdayCity = birthdayCity,
                Birthday = birthday,
                Password = password,
                Email = email,
                Mobile = mobile
            };
            try
            {
                _registrationService.RegistrateUser(user);
                result = "User was registered successful!";
                return this.RedirectToAction("Index", "Autorization");
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            ViewBag.Result = result;
            return View("Registration");
        }
    }
}
