using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillBill_Chat_WebAPI.Services;

namespace SkillBill_Chat_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatOverviewController : ControllerBase
    {
        IChatOverviewService _chatOverviewService;
        public SqlClientService _sqlClientService;
        public ChatOverviewController(ISqlClientService sqlClientService, IChatOverviewService chatOverviewService)
        {
            _sqlClientService = (SqlClientService?)sqlClientService;
            _chatOverviewService = chatOverviewService;
        }
        [HttpGet]
        [Route("testing")]
        public ActionResult GetChatOverviewByIdAndDate(int id, DateTime userLastVisitDate)
        {
            var chatOverview = _sqlClientService.FromDatabase(id, userLastVisitDate);
            if (chatOverview == null)
                return NotFound();
            var chatOverviewDTO = _chatOverviewService.ToChatOverviewDTO(chatOverview);

            return Ok(chatOverviewDTO);
        }
    }
}
