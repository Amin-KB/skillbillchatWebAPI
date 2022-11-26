namespace SkillBill_Chat_WebAPI.Models
{
    public record Message
    {
     
        public int UserId { get; init; }
        public int MsgType { get; init; }
        public DateTime MsgDate { get; init; }
        public string MsgText { get; init; }
        public string? Appendix { get; init; }
    }
}
