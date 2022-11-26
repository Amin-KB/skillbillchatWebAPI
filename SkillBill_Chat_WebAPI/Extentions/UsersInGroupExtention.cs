using SkillBill_Chat_WebAPI.Models.Requests;
using SkillBill_Chat_WebAPI.Models;
using SkillBill_Chat_WebAPI.Services;
using System.Data.SqlClient;
using System.Data;

namespace SkillBill_Chat_WebAPI.Extentions
{
    public static class UsersInGroupExtention
    {
        static string connectionString => SqlClientService.GetConnectionstring;
        public static UsersInGroup GetAllUsersInAGroup(this GroupInfoRequest usersInGroupRequest)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [dbo].[fn_GetUsersInGroup](@groupName)", con);
                sqlCommand.Parameters.AddWithValue("@groupName", SqlDbType.NVarChar).Value = usersInGroupRequest.GroupName;
                con.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();
                var usersInGroup = new UsersInGroup();
                while (sqlDataReader.Read())
                {
                    usersInGroup.GroupId = Convert.ToInt32(sqlDataReader["GroupId"]);
                    usersInGroup.GroupName = sqlDataReader["groupName"].ToString();
                    usersInGroup.Users.Add(new User()
                    {
                        Id = Convert.ToInt32(sqlDataReader["UserId"]),
                        Firstname = sqlDataReader["FirstName"].ToString(),
                        Lastname = sqlDataReader["LastName"].ToString(),
                        Username = sqlDataReader["UserName"].ToString(),
                        Email = sqlDataReader["Email"].ToString()
                    });
                }
                return usersInGroup;

            }
        }
    }
}
