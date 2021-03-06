using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Interfaces;
using System;
using SocialNetwork.BLL.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.PL.Controllers
{
    public class MessListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IMessListService _messListService;

        public MessListController(IMessListService messListService)
        {
            _messListService = messListService;
        }

        [HttpGet(nameof(GetAllChats))]
        public IActionResult GetAllChats(int userId)
        {
            string result = "List CHATS:\n\nUser_Id - " + _messListService.GetUserById(userId) + ", have chat:\n";
            try
            {
                if (_messListService.GetAllMessLists(userId).Count == 0) throw new ValidationException("User has't chats...", "");
                foreach (var item in _messListService.GetAllMessLists(userId))
                {
                    result += "---with---: ";
                    if (userId == item.User2_Id)
                    {
                        result += _messListService.GetUserById(item.User1_Id);
                    }
                    else if (userId == item.User1_Id)
                    {
                        result += _messListService.GetUserById(item.User2_Id);
                    }
                    result += '\n';
                }
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }
    }
}
