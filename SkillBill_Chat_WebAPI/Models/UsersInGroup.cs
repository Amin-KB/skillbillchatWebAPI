namespace SkillBill_Chat_WebAPI.Models
{
    public class UsersInGroup
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
