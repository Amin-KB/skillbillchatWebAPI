SET QUOTED_IDENTIFIER ON
GO
-- ---------------------------------------------------------------------
-- Author: Amin Karam Beigi
-- Save Message info
--        
-- ---------------------------------------------------------------------
-- 2022-11-25: 

CREATE OR ALTER PROCEDURE pr_SaveChatMsg @userId INT,@groupId INT,@messageType INT,@messageText NVARCHAR(MAX),@appendix NVARCHAR(MAX)
 AS
   BEGIN
   INSERT INTO ChatMess VALUES(@userId,@groupId,@messageType,GETDATE(),@messageText,@appendix)
   END

GO


-- ---------------------------------------------------------------------
-- Author: Amin Karam Beigi
-- Returns the all Messages in a group chat
--        
-- ---------------------------------------------------------------------
-- 2022-11-25: 
CREATE OR ALTER FUNCTION dbo.fn_GetAllMsgsInGroup(@groupId INT)
RETURNS TABLE
  AS
   RETURN(SELECT * FROM ChatMess
    WHERE GroupId=@groupId)

GO


-- ---------------------------------------------------------------------
-- Author: Amin Karam Beigi
-- Returns UserId FirstName LastName UserName Email PhoneNumber
--   GroupId GroupName    
-- ---------------------------------------------------------------------
-- 2022-11-25: 
CREATE OR ALTER FUNCTION fn_GetUsersInGroup (@groupName NVARCHAR(30))
RETURNS @user TABLE
( UserId INT,FirstName NVARCHAR(50),
  LastName NVARCHAR(50),UserName NVARCHAR(50),
  Email NVARCHAR(50),PhoneNumber NVARCHAR(100),
  GroupId INT,GroupName NVARCHAR(30))
  AS
    BEGIN 
      INSERT INTO @user
      SELECT DISTINCT cm.UserId,asu.FirstName,asu.LastName,
	  asu.UserName,asu.Email,asu.PhoneNumber,gr.Id,gr.GroupName FROM Groups gr
	  JOIN ChatMess cm ON gr.Id=cm.GroupId
	  JOIN AspNetUsers asu ON cm.UserId= asu.Id
	  WHERE gr.GroupName=@groupName
	 RETURN
   END

   -- ---------------------------------------------------------------------
-- Author: 
-- returns User, Chats, total/unread Messages
--         , last Message: Date, User, Text
-- ---------------------------------------------------------------------
-- 2022-11-21: 


CREATE OR ALTER FUNCTION [dbo].[ChatGroupOverview] 
( @UserId int, @UserLastVisit datetime = NULL)
RETURNS @ChatGroups TABLE 
(
	ID_GROUP int NOT NULL, GROUPNAME nvarchar(50)
	, MessTotal int, MessUnread int
	, LastMsgDate smalldatetime, LastMsgUser nvarchar(50), LastMsgText nvarchar(150)
	, InfoMsg nvarchar(256)
)
AS
BEGIN
	insert into @ChatGroups select 
	cs.GroupId, Groups.GroupName, count(*), 0, null, '', '', '' from ChatMess cs
	 INNER JOIN Groups on cs.GroupId = Groups.Id
	 where cs.UserId = @UserId
	 group by cs.GroupId, Groups.GroupName


	begin -- count unRead Msg for User in Group
		declare @CntUnread int, @Cnt4Grp int;
		DECLARE curCnt CURSOR FOR select ID_GROUP from @ChatGroups order by ID_GROUP
		open curCnt;
		fetch next from curCnt into @Cnt4Grp;
		while @@FETCH_STATUS = 0
		begin
			select @CntUnread = count(*) from ChatMess 
			   where GroupId = @Cnt4Grp and MessDate >= @UserLastVisit;
			update @ChatGroups set MessUnread = @CntUnread where ID_GROUP = @Cnt4Grp;

			-- get last infos for Group
			declare @LastMsgId int, @LastMsgText nvarchar(150), @LastMsgDate smalldatetime, @LastMsgUser nvarchar(50);
			select @LastMsgId = Max(id) from ChatMess where ChatMess.GroupId = @Cnt4Grp
			update @ChatGroups set InfoMsg = 'LastMsgId for Group ' + cast(@Cnt4Grp AS nvarchar(5)) + ': ' + cast(@LastMsgId AS nvarchar(5)) where ID_GROUP = @Cnt4Grp
			select @LastMsgText = cast(@Cnt4Grp AS nvarchar(5)) + MessText from ChatMess where Id = @LastMsgId;
			select @LastMsgDate = MessDate from ChatMess where Id = @LastMsgId;
			select @LastMsgUser = cast(cm.UserId AS nvarchar(5)) + '; ' + us.FirstName from ChatMess cm
				inner join AspNetUsers us on us.Id = cm.UserId where cm.Id = @LastMsgId;
			update @ChatGroups set LastMsgText = @LastMsgText, LastMsgDate = @LastMsgDate, LastMsgUser = @LastMsgUser
				where ID_GROUP = @Cnt4Grp;

			fetch next from curCnt into @Cnt4Grp;
		end
		close curCnt;
		deallocate curCnt;
	end

	return

END
GO