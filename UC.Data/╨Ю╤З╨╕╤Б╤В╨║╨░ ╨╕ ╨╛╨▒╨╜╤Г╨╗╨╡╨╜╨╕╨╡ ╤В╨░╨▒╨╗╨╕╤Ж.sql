delete from sh_Articles
DBCC CHECKIDENT ('sh_Articles', RESEED, 0)
go

delete from sh_Categories
DBCC CHECKIDENT ('sh_Categories', RESEED, 0)
go

delete from sh_Comments
DBCC CHECKIDENT ('sh_Comments', RESEED, 0)
go

delete from sh_Keywords
DBCC CHECKIDENT ('sh_Keywords', RESEED, 0)
go

delete from tbh_Products
DBCC CHECKIDENT ('tbh_Products', RESEED, 0)
go

/*delete from sh_Manufacturers
DBCC CHECKIDENT ('sh_Manufacturers', RESEED, 0)
go

delete from tbh_Departments
DBCC CHECKIDENT ('tbh_Departments', RESEED, 0)
go

delete from sh_Newsletters
DBCC CHECKIDENT ('sh_Newsletters', RESEED, 0)
go

delete from sh_Pages
DBCC CHECKIDENT ('sh_Pages', RESEED, 0)
go

delete from sh_ParsingCatalogs
DBCC CHECKIDENT ('sh_ParsingCatalogs', RESEED, 0)
go

delete from sh_ParsingProducts
DBCC CHECKIDENT ('sh_ParsingProducts', RESEED, 0)
go

delete from sh_Requests
DBCC CHECKIDENT ('sh_Requests', RESEED, 0)
go

delete from sh_SearchRequests
DBCC CHECKIDENT ('sh_SearchRequests', RESEED, 0)
go

delete from sh_Sessions
DBCC CHECKIDENT ('sh_Sessions', RESEED, 0)
go

delete from sh_Sites
DBCC CHECKIDENT ('sh_Sites', RESEED, 0)
go

delete from tbh_Forums
DBCC CHECKIDENT ('tbh_Forums', RESEED, 0)
go

delete from tbh_OrderItems
DBCC CHECKIDENT ('tbh_OrderItems', RESEED, 0)
go

delete from tbh_Orders
DBCC CHECKIDENT ('tbh_Orders', RESEED, 0)
go

delete from tbh_Posts
DBCC CHECKIDENT ('tbh_Posts', RESEED, 0)
go

delete from aspnet_WebEvent_Events
go

delete from aspnet_Profile
go*/


delete 
from aspnet_Users 
where
username != 'admin'
go

/*delete 
from aspnet_Membership 
where userid != (select userid from aspnet_Users where username = 'admin')
go

delete
from aspnet_UsersInRoles
where userid != (select userid from aspnet_Users where username = 'admin')
go*/


delete from aspnet_PersonalizationAllUsers
go

delete from aspnet_Paths
go

delete from aspnet_applications where applicationName=N'/TBH_Web'
go

