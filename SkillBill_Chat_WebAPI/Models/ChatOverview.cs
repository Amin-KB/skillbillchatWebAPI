using System.Security.Cryptography;

namespace ASPnet_Core_Web_API.Model
{
    public record ChatOverview
    {
        // ID_GROUP	GROUPNAME	MessTotal	MessUnread	LastMsgDate	LastMsgUser	LastMsgText	InfoMsg
        // 4	AP11	2	2	2022-11-21 08:00:00	29; Hermann	4work in progress LastMsgId for Group 4: 16
        // 6	Foyer	1	1	2022-11-21 00:00:00	29; Hermann	6welcome im Foyer LastMsgId for Group 6: 14
        
        public int GroupId{ get; init; }
        public string GroupName { get; init; }
        public int MessTotal { get; init; }
        public int MessUnread { get; init; }
        public DateTime LastMsgDate { get; init; }
        public string LastMsgUser { get; init; }
        public string LastMsgText { get; init; }

      
    }
}
