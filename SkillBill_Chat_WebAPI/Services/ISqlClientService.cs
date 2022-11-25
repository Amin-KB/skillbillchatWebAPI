using ASPnet_Core_Web_API.Model;
using System.Data.SqlClient;

namespace SkillBill_Chat_WebAPI.Services
{
    public interface ISqlClientService
    {
        public ChatOverview FromDatabase(int userId, DateTime dateTime);
    }
}
