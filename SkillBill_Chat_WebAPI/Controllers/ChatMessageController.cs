using ASPnet_Core_Web_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillBill_Chat_WebAPI.Extentions;
using SkillBill_Chat_WebAPI.Services;

namespace SkillBill_Chat_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        public SqlClientService _sqlClientService;
        public ChatMessageController(ISqlClientService sqlClientService)
        {
            _sqlClientService = (SqlClientService?)sqlClientService;

        }
        [HttpPost]
        [Route("save")]
        public IActionResult Save(ChatMessage chatMessageRequest)
        {
            var chatMessage = chatMessageRequest.SafeRequest();
            int success=chatMessage.SaveInDataBase();
            if (success == 0) 
                return BadRequest("Something went wrong");
            else
                return Ok("OK");
        }
    }
}
