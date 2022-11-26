namespace SkillBill_Chat_WebAPI.Models
{
    public class MessagesInGroup
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public  List<Message> Messages { get; set; }=new List<Message>();   
        public MessagesInGroup()
        {
          
        }
    }
}
