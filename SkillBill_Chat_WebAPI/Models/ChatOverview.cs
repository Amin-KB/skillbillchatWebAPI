using System.Security.Cryptography;

namespace ASPnet_Core_Web_API.Model
{
    public class ChatOverview
    {

        // ID_GROUP	GROUPNAME	MessTotal	MessUnread	LastMsgDate	LastMsgUser	LastMsgText	InfoMsg
        // 4	AP11	2	2	2022-11-21 08:00:00	29; Hermann	4work in progress LastMsgId for Group 4: 16
        // 6	Foyer	1	1	2022-11-21 00:00:00	29; Hermann	6welcome im Foyer LastMsgId for Group 6: 14
        public ChatOverview(int id_Group, string groupName, int messTotal, int messUnread
            , DateTime lastMsgDate, string lastMsgUser, string lastMsgText)
        {
            ID_GROUP = id_Group;
            GroupName = groupName;
            MessTotal = messTotal;
            MessUnread = messUnread;
            LastMsgDate = lastMsgDate;
            LastMsgUser = lastMsgUser;
            LastMsgText = lastMsgText;
        }
        public ChatOverview(int id_Group, string groupName, int messTotal, int messUnread
       , string lastMsgDate, string lastMsgUser, string lastMsgText)
        {
            ID_GROUP = id_Group;
            GroupName = groupName;
            MessTotal = messTotal;
            MessUnread = messUnread;
            LastMsgDate = DateTime.Parse(lastMsgDate);
            LastMsgUser = lastMsgUser;
            LastMsgText = lastMsgText;
        }

        //We need this constructor for mapping
        public ChatOverview()
        {

        }
        public int ID_GROUP { get; set; }
        public string GroupName { get; set; }
        public int MessTotal { get; set; }
        public int MessUnread { get; set; }
        public DateTime LastMsgDate { get; set; }
        public string LastMsgUser { get; set; }
        public string LastMsgText { get; set; }

        public override string ToString()
        {
            return ID_GROUP + "/" + GroupName + ", Msg Tot/unread " + MessTotal + "/" + MessUnread 
                   + ", Last " + LastMsgUser + "/" + LastMsgText;
        }
    }
}
