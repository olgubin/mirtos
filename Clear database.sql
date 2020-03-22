--TRUNCATE TABLE aspnet_WebEvent_Events

--delete from aspnet_Profile where UserId in (select UserId from aspnet_Users where IsAnonymous=1 and LastActivityDate<='2021-01-01')


--delete from aspnet_Users where IsAnonymous=1


--delete from sh_Sessions


--alter table sh_Sessions rebuild


--delete from sh_Requests


--alter table sh_Requests rebuild


