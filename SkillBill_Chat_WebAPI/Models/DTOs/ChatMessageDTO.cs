namespace SkillBill_Chat_WebAPI.Models.DTOs
{
    public record ChatMessageDTO
    {
        public int Id { get; init; }
        public int GroupId { get; init; }
        public int UserId { get; init; }
      
        public int MsgType { get; init; }
        public DateTime MsgDate { get; init; }
        public string MsgText { get; init; }
        public string? Appendix { get; init; }

    }
}
