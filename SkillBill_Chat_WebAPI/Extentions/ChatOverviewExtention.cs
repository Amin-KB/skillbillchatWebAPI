using ASPnet_Core_Web_API.Model;
using Newtonsoft.Json;
using SkillBill_Chat_WebAPI.Models.DTOs;
using SkillBill_Chat_WebAPI.Models.Requests;
using System.Data.SqlClient;
using System.Data;
using SkillBill_Chat_WebAPI.Services;

namespace SkillBill_Chat_WebAPI.Extentions
{
    public static class ChatOverviewExtention
    {
        static string connectionString => SqlClientService.GetConnectionstring;
        /// <summary>
        /// This Extention method mapps ChatOverview to Data Transfer Object
        /// </summary>
        /// <param name="chatOverview"></param>
        /// <returns>ChatOverviewDTO</returns>
        public static ChatOverviewDTO ToDTO(this ChatOverview? chatOverview)
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

        /// <summary>
        /// This Extention method helps to avoid this error: "the json value could not be converted to system.datetime"
        /// </summary>
        /// <param name="chatOverviewRequest"></param>
        /// <returns></returns>
        public static ChatOverviewRequest SafeRequest(this ChatOverviewRequest chatOverviewRequest)
        {
            var chatOverviewRequeststr = JsonConvert.SerializeObject(chatOverviewRequest);
            return JsonConvert.DeserializeObject<ChatOverviewRequest>(chatOverviewRequeststr);
        }
        /// <summary>
        /// This Method gets all the Chat information base on the last visit from database
        /// </summary>
        /// <param name="chatOverviewRequest"></param>
        /// <returns>ChatOverview</returns>
        public static ChatOverview GetChatGroupOrview(this ChatOverviewRequest chatOverviewRequest)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [dbo].[ChatGroupOverview](@UserId,@UserLastVisit)", con);
                sqlCommand.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value= chatOverviewRequest.Id;
                sqlCommand.Parameters.AddWithValue("@UserLastVisit", SqlDbType.SmallDateTime).Value= chatOverviewRequest.UserLastVisitDate;
                con.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();
                return GetchatOverview(sqlDataReader);

            }

        }
        public static ChatOverview GetchatOverview(SqlDataReader sqlDataReader)
        {
            if (sqlDataReader.Read())
            {
                var ChatOverview = new ChatOverview(Convert.ToInt32(sqlDataReader["ID_GROUP"]), sqlDataReader["GROUPNAME"].ToString(),
                    Convert.ToInt32(sqlDataReader["MessTotal"]), Convert.ToInt32(sqlDataReader["MessUnread"]),Convert.ToDateTime( sqlDataReader["LastMsgDate"]),
                    sqlDataReader["LastMsgUser"].ToString(), sqlDataReader["LastMsgText"].ToString());
                return ChatOverview;
            }
            return null;
        }
    }
}
