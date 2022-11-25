using ASPnet_Core_Web_API.Model;
using SkillBill_Chat_WebAPI.Models.DTOs;
using System.Text.RegularExpressions;

namespace SkillBill_Chat_WebAPI.Extentions
{
    public static class Extention
    {

        public static ChatMessage ToChatMessage(ChatMessageDTO chatMessageDTO)
        {
            return  new ChatMessage()
            {
                Id= chatMessageDTO.Id,
                GroupId= chatMessageDTO.GroupId,
                UserId= chatMessageDTO.UserId,
                MsgDate= chatMessageDTO.MsgDate,
                MsgText= chatMessageDTO.MsgText,
                Appendix= chatMessageDTO.Appendix,
            };
        }
        public static ChatMessageDTO ToChatMessageDTO(ChatMessage chatMessage)
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
 

        public static string GetRootPath(string rootFilename)
        {
            string _root;
            var rootDir = System.IO.Path.GetDirectoryName(
                      System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex matchThepath = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = matchThepath.Match(rootDir).Value;
            _root = Path.Combine(appRoot, rootFilename);

            return _root;
        }
        public static IConfiguration GetConfig()
        {

            var config = (IConfiguration)new ConfigurationBuilder().AddJsonFile(GetRootPath("Databasesettings.json")).Build();

            return config;

        }

    }
}
