USE [CityClimate]
go

/****** Object:  Table [dbo].[UC_Product_DepartmentMappings]    Script Date: 05/24/2009 19:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UC_Product_DepartmentMappings](
	[ProductDepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL CONSTRAINT [DF_UC_Product_DepartmentMappings_DisplayOrder]  DEFAULT ((0)),
 CONSTRAINT [PK_UC_Product_DepartmentMappings] PRIMARY KEY CLUSTERED 
(
	[ProductDepartmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[UC_Product_DepartmentMappings]  WITH CHECK ADD  CONSTRAINT [FK_UC_Product_DepartmentMappings_tbh_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tbh_Products] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UC_Product_DepartmentMappings] CHECK CONSTRAINT [FK_UC_Product_DepartmentMappings_tbh_Products]
GO
ALTER TABLE [dbo].[UC_Product_DepartmentMappings]  WITH CHECK ADD  CONSTRAINT [FK_UC_Product_DepartmentMappings_UC_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[UC_Departments] ([DepartmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UC_Product_DepartmentMappings] CHECK CONSTRAINT [FK_UC_Product_DepartmentMappings_UC_Departments]
