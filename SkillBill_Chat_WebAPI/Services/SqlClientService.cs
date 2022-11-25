using ASPnet_Core_Web_API.Model;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using SkillBill_Chat_WebAPI.Extentions;

namespace SkillBill_Chat_WebAPI.Services
{
    public class SqlClientService:ISqlClientService
    {
        static IConfiguration _configuration=Extention.GetConfig();
     
        
        static string GetConnectionstring= _configuration.GetSection("ConnectionStrings")["DefaultConnection"];
        public ChatOverview FromDatabase(int userId,DateTime userLastVisitDate)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionstring))
            {
                SqlParameter id = new SqlParameter("@UserId", SqlDbType.Int);
                SqlParameter userLastVisit = new SqlParameter("@UserLastVisit", SqlDbType.DateTime);
                id.Value = userId;
                userLastVisit.Value = userLastVisitDate;
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [dbo].[ChatGroupOverview](@UserId,@UserLastVisit)", con);
                sqlCommand.Parameters.Add(id);
                sqlCommand.Parameters.Add(userLastVisit);
                con.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();
                return GetchatOverview(sqlDataReader);
             
            }

        }
        public ChatOverview GetchatOverview(SqlDataReader sqlDataReader)
        {
            if (sqlDataReader.Read())
            {
                var ChatOverview = new ChatOverview(Convert.ToInt32(sqlDataReader["ID_GROUP"]), sqlDataReader["GROUPNAME"].ToString(),
                    Convert.ToInt32(sqlDataReader["MessTotal"]), Convert.ToInt32(sqlDataReader["MessUnread"]), sqlDataReader["LastMsgDate"].ToString(),
                    sqlDataReader["LastMsgUser"].ToString(), sqlDataReader["LastMsgText"].ToString());
                return ChatOverview;
            }
            return null;
        }
       

    }
}
