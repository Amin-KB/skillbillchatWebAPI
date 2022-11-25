USE [SkillBill]
GO

/****** Object:  UserDefinedFunction [dbo].[ChatGroupOverview]    Script Date: 25.11.2022 08:25:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ---------------------------------------------------------------------
-- Author: 
-- returns User, Chats, total/unread Messages
--         , last Message: Date, User, Text
-- ---------------------------------------------------------------------
-- 2022-11-21: 



CREATE FUNCTION [dbo].[ChatGroupOverview] 
( @UserId int, @UserLastVisit smalldatetime = null)
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

begin transaction

select max(LastVisit) from ChatUserinGroup where UserId = 29

insert into ChatUserinGroup values (29, 2, null);
insert into ChatUserinGroup values (29, 4, null);

insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 29, 0, '20221121', 'welcome im Foyer', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 29, 0, '20221114', 'welcome in AK11', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 29, 0, '20221121', 'work in progress', null );

select cs.GroupId, Groups.GroupName, count(*), count(*) from ChatMess cs
	 INNER JOIN Groups on cs.GroupId = Groups.Id
	 where cs.UserId = 29
	 group by cs.GroupId, Groups.GroupName

rollback
-- commit
