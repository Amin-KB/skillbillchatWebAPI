using ASPnet_Core_Web_API.Model;
using SkillBill_Chat_WebAPI.Models.Requests;
using System.Data.SqlClient;
using System.Data;
using SkillBill_Chat_WebAPI.Models;
using SkillBill_Chat_WebAPI.Services;

namespace SkillBill_Chat_WebAPI.Extentions
{
    public static class MessagesInGroupExtention
    {
        static string connectionString => SqlClientService.GetConnectionstring;
        /// <summary>
        /// This Method gets all existing Messages in a chat group
        /// </summary>
        /// <param name="messagesInGroupRequest"></param>
        /// <returns>MessagesInGroup</returns>
        public static MessagesInGroup GetAllMessagesInAGroup(this GroupInfoRequest messagesInGroupRequest)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [dbo].[fn_GetAllMsgsInGroupByGroupName](@groupName)", con);
                sqlCommand.Parameters.AddWithValue("@groupName", SqlDbType.NVarChar).Value = messagesInGroupRequest.GroupName;
                con.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();
                var messagesInGroup = new MessagesInGroup();
                while (sqlDataReader.Read())
                {
                    messagesInGroup.GroupId = Convert.ToInt32(sqlDataReader["GroupId"]);
                    messagesInGroup.GroupName = sqlDataReader["groupName"].ToString();
                    messagesInGroup.Messages.Add(new Message()
                    {
                        UserId = Convert.ToInt32(sqlDataReader["UserId"]),
                        MsgType= Convert.ToInt32(sqlDataReader["MessTyp"]),
                        MsgDate= Convert.ToDateTime(sqlDataReader["MessDate"]),
                        MsgText= sqlDataReader["MessText"].ToString(),
                        Appendix= sqlDataReader["Appendix"].ToString()
                    });
                }
                return messagesInGroup;

            }

        }
    }
}
