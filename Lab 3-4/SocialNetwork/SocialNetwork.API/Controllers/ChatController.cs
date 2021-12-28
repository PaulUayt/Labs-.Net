using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.BLL.DTO;

namespace SocialNetwork.API.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet(nameof(GetChatWithUser))]
        public IActionResult GetChatWithUser(int? messList_id)
        {
            string result = "Chat - " + messList_id + "\n\n";
            try
            {
                foreach (var item in _chatService.GetChatByMessListId(messList_id))
                {
                    result += _chatService.GetNameById(item.FromUser_Id) + ": " + item.Text;
                    result += '\n';
                }
                return Ok(result);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }

        [HttpPost(nameof(SendMess))]
        public IActionResult SendMess(MessListDTO messListDTO, string text)
        {
            string result = "Message send succesfull!";
            try
            {
                _chatService.SendMess(messListDTO, text);
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }
    }
}
