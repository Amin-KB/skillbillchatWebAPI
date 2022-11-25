namespace SkillBill_Chat_WebAPI.Models.DTOs
{
    public record ChatOverviewDTO
    {
        public int ID_GROUP { get; init; }
        public string GroupName { get; init; }
        public int MessTotal { get; init; }
        public int MessUnread { get; init; }
        public DateTime LastMsgDate { get; init; }
        public string LastMsgUser { get; init; }
        public string LastMsgText { get; init; }
    }
}
