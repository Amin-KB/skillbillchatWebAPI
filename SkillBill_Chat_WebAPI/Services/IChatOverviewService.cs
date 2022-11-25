using ASPnet_Core_Web_API.Model;
using SkillBill_Chat_WebAPI.Models.DTOs;

namespace SkillBill_Chat_WebAPI.Services
{
    public interface IChatOverviewService
    {
        public ChatOverview ToChatOverview(ChatOverviewDTO chatOverviewDTO);
        public ChatOverviewDTO ToChatOverviewDTO(ChatOverview chatOverview);
    }
}
