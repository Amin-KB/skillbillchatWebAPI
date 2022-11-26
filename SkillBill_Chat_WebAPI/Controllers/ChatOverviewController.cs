using ASPnet_Core_Web_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillBill_Chat_WebAPI.Models.Requests;
using SkillBill_Chat_WebAPI.Services;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Security.Principal;
using SkillBill_Chat_WebAPI.Extentions;

namespace SkillBill_Chat_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatOverviewController : ControllerBase
    {
       
        public SqlClientService _sqlClientService;
        public ChatOverviewController(ISqlClientService sqlClientService)
        {
            _sqlClientService = (SqlClientService?)sqlClientService;
            
        }
        [HttpPost]
        [Route("getChatOverviewByIdAndDate")]
        public ActionResult GetChatOverviewByIdAndDate(ChatOverviewRequest chatOverviewRequest)
        {           
            var chatOverview = chatOverviewRequest.SafeRequest().FromDatabase();
            if (chatOverview == null)
                return NotFound();
            var chatOverviewDTO = chatOverview.ToDTO();

            return Ok(chatOverviewDTO);
        }
        
    }
}
