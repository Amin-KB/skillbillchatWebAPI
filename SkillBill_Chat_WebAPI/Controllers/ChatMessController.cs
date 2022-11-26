using ASPnet_Core_Web_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillBill_Chat_WebAPI.Extentions;
using SkillBill_Chat_WebAPI.Models.Requests;

namespace SkillBill_Chat_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessController : ControllerBase
    {
        /// <summary>
        /// call this function in sql server: [dbo].[ChatGroupOverview]
        /// </summary>
        /// <param name="chatOverviewRequest"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("getChatOverviewByIdAndDate")]
        public ActionResult GetChatOverviewByIdAndDate(ChatOverviewRequest chatOverviewRequest)
        {
            var chatOverview = chatOverviewRequest.SafeRequest().GetChatGroupOrview();
            if (chatOverview == null)
                return NotFound();
            var chatOverviewDTO = chatOverview.ToDTO();

            return Ok(chatOverviewDTO);
        }
        /// <summary>
        /// call this store procedure in sql server : pr_SaveChatMsg
        /// </summary>
        /// <param name="chatMessageRequest"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("save")]
        public IActionResult Save(ChatMessage chatMessageRequest)
        {
            var chatMessage = chatMessageRequest.SafeRequest();
            int success = chatMessage.SaveInDataBase();
            if (success == 0)
                return BadRequest("Something went wrong");
            else
                return Ok("OK");
        }

        /// <summary>
        /// call this function in sql server: [dbo].[fn_GetAllMsgsInGroupByGroupName]
        /// </summary>
        /// <param name="messagesInGroupRequest"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("getAllMessagesinGroupByName")]
        public IActionResult GetAllMessagesinGroupByName(GroupInfoRequest messagesInGroupRequest)
        {
            var messagesInGroup = messagesInGroupRequest.GetAllMessagesInAGroup();
            return Ok(messagesInGroup);
        }
        /// <summary>
        ///  call this function in sql server: [dbo].[fn_GetUsersInGroup]
        /// </summary>
        /// <param name="usersInGroupRequest"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("getAllUsersinGroupByName")]
        public IActionResult GetAllUsersinGroupByName(GroupInfoRequest usersInGroupRequest)
        {
            var usersInGroup = usersInGroupRequest.GetAllUsersInAGroup();
            return Ok(usersInGroup);
        }
    }
}
