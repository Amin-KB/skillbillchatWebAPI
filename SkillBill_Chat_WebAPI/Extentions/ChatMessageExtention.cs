using ASPnet_Core_Web_API.Model;
using SkillBill_Chat_WebAPI.Models.Requests;
using SkillBill_Chat_WebAPI.Services;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using SkillBill_Chat_WebAPI.Models.DTOs;
using SkillBill_Chat_WebAPI.Models;
using System.Text.RegularExpressions;

namespace SkillBill_Chat_WebAPI.Extentions
{
    public static class ChatMessageExtention
    {
        static string connectionString => SqlClientService.GetConnectionstring;

        /// <summary>
        /// This Method saves a message  in ChatMess Table and returns 1 if it is successful and 0 if it is not
        /// </summary>
        /// <param name="chatMessage"></param>
        /// <returns>int</returns>
        public static int SaveInDataBase(this ChatMessage chatMessage)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("pr_SaveChatMsg", sqlCon);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", SqlDbType.Int).Value = chatMessage.UserId;
                cmd.Parameters.AddWithValue("@groupId", SqlDbType.Int).Value = chatMessage.GroupId;
                cmd.Parameters.AddWithValue("@messageType", SqlDbType.Int).Value = chatMessage.MsgType;
                cmd.Parameters.AddWithValue("@messageText", SqlDbType.NVarChar).Value = chatMessage.MsgText;
                cmd.Parameters.AddWithValue("@appendix", SqlDbType.NVarChar).Value = chatMessage.Appendix;
                int success= cmd.ExecuteNonQuery();
                if (success == 1)
                    return 1;
                sqlCon.Close();
                return 0;   
            }
        }
        /// <summary>
        /// This Extention method helps to avoid this error: "the json value could not be converted to system.datetime"
        /// </summary>
        /// <param name="chatOverviewRequest"></param>
        /// <returns>ChatMessage</returns>
        public static ChatMessage SafeRequest(this ChatMessage chatMessageRequest)
        {
            var chatMessageRequeststr = JsonConvert.SerializeObject(chatMessageRequest);
            return JsonConvert.DeserializeObject<ChatMessage>(chatMessageRequeststr);
        }

        /// <summary>
        /// This Method mapps ChatMessageDTO to ChatMessage
        /// </summary>
        /// <param name="chatMessageDTO"></param>
        /// <returns>ChatMessage</returns>
        public static ChatMessage ToChatMessage(this ChatMessageDTO chatMessageDTO)
        {
            return new ChatMessage()
            {
                Id = chatMessageDTO.Id,
                GroupId = chatMessageDTO.GroupId,
                UserId = chatMessageDTO.UserId,
                MsgDate = chatMessageDTO.MsgDate,
                MsgText = chatMessageDTO.MsgText,
                Appendix = chatMessageDTO.Appendix,
            };
        }
        /// <summary>
        /// This Method mapps ChatMessage to ChatMessageDTO
        /// </summary>
        /// <param name="chatMessage"></param>
        /// <returns>ChatMessageDTO</returns>
        public static ChatMessageDTO ToChatMessageDTO(this ChatMessage chatMessage)
        {
            return new ChatMessageDTO()
            {
                Id = chatMessage.Id,
                GroupId = chatMessage.GroupId,
                UserId = chatMessage.UserId,
                MsgDate = chatMessage.MsgDate,
                MsgText = chatMessage.MsgText,
                Appendix = chatMessage.Appendix,
            };
        }
        public static string ToString(this ChatMessage chatMessage)
        {
            return chatMessage.Id + "/" + chatMessage.GroupId + "/" + chatMessage.UserId + ", Msg Typ/Date/Txt " + chatMessage.MsgType + "/" + chatMessage.MsgDate + "/" + chatMessage.MsgText;
        }

    }
}
