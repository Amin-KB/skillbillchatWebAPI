using ASPnet_Core_Web_API.Model;
using SkillBill_Chat_WebAPI.Models.DTOs;
using System.Data.SqlClient;

namespace SkillBill_Chat_WebAPI.Services
{
    public class ChatOverviewService: IChatOverviewService
    {
        public ChatOverview ToChatOverview(ChatOverviewDTO chatOverviewDTO)
        {
            return new ChatOverview()
            {
                ID_GROUP = chatOverviewDTO.ID_GROUP,
                GroupName = chatOverviewDTO.GroupName,
                MessTotal = chatOverviewDTO.MessTotal,
                MessUnread = chatOverviewDTO.MessUnread,
                LastMsgDate = chatOverviewDTO.LastMsgDate,
                LastMsgUser = chatOverviewDTO.LastMsgUser,
                LastMsgText = chatOverviewDTO.LastMsgText,
            };
        }
        public ChatOverviewDTO ToChatOverviewDTO(ChatOverview chatOverview)
        {
            return new ChatOverviewDTO()
            {
                ID_GROUP = chatOverview.ID_GROUP,
                GroupName = chatOverview.GroupName,
                MessTotal = chatOverview.MessTotal,
                MessUnread = chatOverview.MessUnread,
                LastMsgDate = chatOverview.LastMsgDate,
                LastMsgUser = chatOverview.LastMsgUser,
                LastMsgText = chatOverview.LastMsgText,
            };
        }
    }
}
