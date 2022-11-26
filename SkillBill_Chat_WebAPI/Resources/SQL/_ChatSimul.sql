USE [SkillBill]

select * from ChatGroupOverview(29, '20220101')
begin transaction
	insert into ChatUserinGroup values (2, 2, null);
	insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 2, 0, getdate(), 'Neuere Kurs: AK12', null );
	select * from ChatGroupOverview(29, '20220101')
rollback
goto ende

begin transaction

insert into ChatUserinGroup values (29, 2, '20221115');
insert into ChatUserinGroup values (29, 4, null);
select * from ChatUserinGroup;
select max(LastVisit) from ChatUserinGroup where UserId = 29

insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 19, 0, '20221114', 'welcome im Foyer', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 19, 0, '20221119', 'welcome in AK11', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 19, 0, '20221121', 'work in progress', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 19, 0, '20221114', 'welcome im Foyer', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 19, 0, '20221019', 'Hello world', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 19, 0, '20221021', 'Testing the connection', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 19, 0, '20220915', 'working', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 19, 0, '20220805', 'comming home', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 19, 0, '20220924', 'im n my way', null );

insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 18, 0, '20221114', 'welcome im Foyer', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 18, 0, '20221119', 'welcome in AK11', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 18, 0, '20221121', 'work in progress', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 18, 0, '20221114', 'welcome im Foyer', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 18, 0, '20221019', 'Hello world', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 18, 0, '20221021', 'Testing the connection', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 18, 0, '20220915', 'working', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 18, 0, '20220805', 'comming home', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 18, 0, '20220924', 'im n my way', null );

insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 17, 0, '20221114', 'welcome im Foyer', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 17, 0, '20221119', 'welcome in AK11', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 17, 0, '20221121', 'work in progress', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 17, 0, '20221114', 'welcome im Foyer', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 17, 0, '20221019', 'Hello world', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 17, 0, '20221021', 'Testing the connection', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 17, 0, '20220915', 'working', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (4, 17, 0, '20220805', 'comming home', null );
insert into ChatMess (GroupId, UserId, MessTyp, MessDate, MessText, Appendix) values (2, 17, 0, '20220924', 'im n my way', null );
select * from ChatMess order by Id;

select cs.GroupId, Groups.GroupName, count(*), count(*) from ChatMess cs
	 INNER JOIN Groups on cs.GroupId = Groups.Id
	 where cs.UserId = 29
	 group by cs.GroupId, Groups.GroupName

rollback
-- commit

ende:
