﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SocialNetwork.BLL.DTO;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;

namespace SocialNetwork.API.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost(nameof(RegisterUser))]
        public IActionResult RegisterUser(string surName, string name, 
            string patronymic, string birthdayCity, string birthday,
            string password, string email, string mobile )
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
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }
    }
}
