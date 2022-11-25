namespace ASPnet_Core_Web_API.Model
{
    public record ChatMessage
    {
        // Id GroupId UserId MessTyp MessDate MessText    Appendix
        // 16	4	29	0	2022-11-21 08:00:00	work in progress NULL
        public ChatMessage(int id, int groupId, int userId, int msgType, DateTime msgDate, string msgText, string appendix)
        {
            Id = id;
            GroupId = groupId;
            UserId = userId;
            MsgType = msgType;
            MsgDate = msgDate;
            MsgText = msgText;
            Appendix = appendix;
        }
        //We need this constructor for mapping
        public ChatMessage()
        {

        }
        public int Id { get; init; }
        public int GroupId { get; init; }
        public int UserId { get; init; }
//        public string GroupName { get; set; }
        public int MsgType { get; init; }
        public DateTime MsgDate { get; init; }
        public string MsgText { get; init; }
        public string? Appendix { get; init; }

        public override string ToString()
        {
            return Id + "/" + GroupId + "/" + UserId + ", Msg Typ/Date/Txt " + MsgType + "/" + MsgDate + "/" + MsgText;
        }
    }
}
