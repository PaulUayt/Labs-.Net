using Microsoft.AspNetCore.Mvc;
using System;
using SocialNetwork.BLL.DTO;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;

namespace SocialNetwork.API.Controllers
{
    public class MainPageController : Controller
    {
        private readonly IMainPageService _mainPageService;

        public MainPageController(IMainPageService mainPageService)
        {
            _mainPageService = mainPageService;
        }

        [HttpGet(nameof(MainPage))]
        public IActionResult MainPage(int userId)
        {
            string result;
            try
            {
                result =  _mainPageService.GetUserById(userId) + "\nCount friends: " + _mainPageService.GetFriendsCount(userId) + " friends.";
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }
    }
}
