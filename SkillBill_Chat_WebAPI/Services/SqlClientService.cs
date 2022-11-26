using ASPnet_Core_Web_API.Model;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using SkillBill_Chat_WebAPI.Extentions;
using SkillBill_Chat_WebAPI.Models.Requests;
using SkillBill_Chat_WebAPI.Helper;

namespace SkillBill_Chat_WebAPI.Services
{
    public class SqlClientService:ISqlClientService
    {
        static IConfiguration _configuration= ConnectionStringHelper.GetConfig();
     
        
        public static string GetConnectionstring= _configuration.GetSection("ConnectionStrings")["DefaultConnection"];
        
       

    }
}
