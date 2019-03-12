USE [XiangXi]
GO

if exists (select name from sys.objects where name='SYS_Code') drop table SYS_Code
/****** Object:  Table [dbo].[SYS_Code]    Script Date: 03/28/2018 14:52:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SYS_Code]( --系统配置（最初用于配置化下拉框，后续可以扩展到任意功能）
	[id] INT IDENTITY(1,1) NOT NULL, --主键ID
	[type] nvarchar(50) NOT NULL, --使用类别（如：system/dropdown/selection/radio）
	[category] [nvarchar](50) NOT NULL,--范畴（如：AGR_Product.type）
	[title] [nvarchar](200) NOT NULL,--配置名称
	[val] [nvarchar](200) NOT NULL,--配置值
	[ord] INT NULL,--排序值
	[VersionNo] int NULL, --数据锁
	[TransactionID] nvarchar(50) NULL, --事务同步机制
	[CreateBy] nvarchar(50) NULL,	--创建人
	[CreateOn] datetime NULL,	--创建时间
	[UpdateBy] nvarchar(50) NULL, --更新人
	[UpdateOn] datetime NULL, --更新时间
	[IsDeleted] int NULL, --是否删除
 CONSTRAINT [PK_SYS_Code] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


exec AddComments N'SYS_Code',N'id',N'配置编号'
exec AddComments N'SYS_Code',N'type',N'使用类别'
exec AddComments N'SYS_Code',N'category',N'范畴'
exec AddComments N'SYS_Code',N'title',N'配置名称'
exec AddComments N'SYS_Code',N'val',N'配置值'
exec AddComments N'SYS_Code',N'ord',N'排序值'

--导航配置
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'module', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'welfare', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'module', -- type - nvarchar(50)
          N'BUS_Document', -- category - nvarchar(50)
          N'business', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'module', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'business', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'module', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'business', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'module', -- type - nvarchar(50)
          N'BUS_SSD_Meeting', -- category - nvarchar(50)
          N'business', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'module', -- type - nvarchar(50)
          N'BUS_Agriculture_Subsidy', -- category - nvarchar(50)
          N'business', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'module', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'business', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
          
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'主页', -- title - nvarchar(200)
          N'../0-Index/index.html',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'ChildrensMedicalInsuranceRegistration', -- category - nvarchar(50)
          N'主页', -- title - nvarchar(200)
          N'../0-Index/index.html',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_SSD_Meeting', -- category - nvarchar(50)
          N'主页', -- title - nvarchar(200)
          N'../0-Index/index.html',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Document', -- category - nvarchar(50)
          N'主页', -- title - nvarchar(200)
          N'../0-Index/index.html',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'主页', -- title - nvarchar(200)
          N'../0-Index/index.html',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'主页', -- title - nvarchar(200)
          N'../0-Index/index.html',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Agriculture_Subsidy', -- category - nvarchar(50)
          N'主页', -- title - nvarchar(200)
          N'../0-Index/index.html',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'主页', -- title - nvarchar(200)
          N'../0-Index/index.html',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'主页', -- title - nvarchar(200)
          N'../0-Index/index.html',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
          
          
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'村民福利', -- title - nvarchar(200)
          N'../9-welfare/welfare.html',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_SSD_Meeting', -- category - nvarchar(50)
          N'村务管理', -- title - nvarchar(200)
          N'../3-business/business.html',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'ChildrensMedicalInsuranceRegistration', -- category - nvarchar(50)
          N'村务管理', -- title - nvarchar(200)
          N'../3-business/business.html',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Document', -- category - nvarchar(50)
          N'村务管理', -- title - nvarchar(200)
          N'../3-business/business.html',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'村务管理', -- title - nvarchar(200)
          N'../3-business/business.html',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'村务管理', -- title - nvarchar(200)
          N'../3-business/business.html',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Agriculture_Subsidy', -- category - nvarchar(50)
          N'村务管理', -- title - nvarchar(200)
          N'../3-business/business.html',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'村务管理', -- title - nvarchar(200)
          N'../3-business/business.html',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'{{request.type}}', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Document', -- category - nvarchar(50)
          N'文件档案管理', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'村建设办证管理', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'土地变更', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Agriculture_Subsidy', -- category - nvarchar(50)
          N'农业补贴登记', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'涉农管理', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'ChildrensMedicalInsuranceRegistration', -- category - nvarchar(50)
          N'少儿医保', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'nav', -- type - nvarchar(50)
          N'BUS_SSD_Meeting', -- category - nvarchar(50)
          N'事务管理', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
          
          
--下拉配置
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'dropdown', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'type', -- title - nvarchar(200)
          N'老年人关爱',  -- val - nvarchar(200)
          0 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'dropdown', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'type', -- title - nvarchar(200)
          N'困难户关爱',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'dropdown', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'type', -- title - nvarchar(200)
          N'免费保险',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'dropdown', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'subtype', -- title - nvarchar(200)
          N'type.困难户关爱=>低保户，边缘户，五保户，大病户，困难户',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'dropdown', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'subtype', -- title - nvarchar(200)
          N'type.免费保险=>人身保险，家庭财产保险',  -- val - nvarchar(200)
          2 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'id', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Agriculture_Subsidy', -- category - nvarchar(50)
          N'id', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'WEL_Sent', -- category - nvarchar(50)
          N'photo', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
          
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'id', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'incert', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'inplowland', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'inwoods', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'inbywork', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'intype', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'inbackup', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'inreason', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'inremark', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'outplowland', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'outwoods', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'outbywork', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'outtype', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'outcert', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'outbackup', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'outreason', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'outremark', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_SSD_Meeting', -- category - nvarchar(50)
          N'id', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Document', -- category - nvarchar(50)
          N'id', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'id', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'householderid', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'buildingarea', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'householdarea', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'originconstruct', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'originbuildingarea', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'originhouseholdarea', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'certarea', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Dev_Cert', -- category - nvarchar(50)
          N'reason', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
          
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'id', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
          
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'woodsarea', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'plowlandarea', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'aquaculturearea', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'aquaculturetype', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'woodsplanttype', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'woodsplantamount', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'raisechickens', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'raiseduck', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'raisegoose', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'BUS_Arg_Register', -- category - nvarchar(50)
          N'raisepig', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
          
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'ChildrensMedicalInsuranceRegistration', -- category - nvarchar(50)
          N'CMIRPhoto', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'hidecolumn', -- type - nvarchar(50)
          N'ChildrensMedicalInsuranceRegistration', -- category - nvarchar(50)
          N'id', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'uploadimage', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'incert', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )
INSERT INTO dbo.SYS_Code
        ( type ,category ,title ,val ,ord ,VersionNo ,TransactionID ,CreateBy ,CreateOn ,UpdateBy ,UpdateOn ,IsDeleted )
VALUES  ( N'uploadimage', -- type - nvarchar(50)
          N'BUS_Land_Change_Cert', -- category - nvarchar(50)
          N'outcert', -- title - nvarchar(200)
          N'',  -- val - nvarchar(200)
          1 , -- ord - int
          0 , -- VersionNo - int
          N'' , -- TransactionID - nvarchar(50)
          N'' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
          )

INSERT INTO dbo.UserInformation
        ( id ,
          UILoginName ,
          UICode ,
          UICustomerType ,
          VersionNo ,
          TransactionID ,
          CreateBy ,
          CreateOn ,
          UpdateBy ,
          UpdateOn ,
          IsDeleted
        )
VALUES  ( NEWID() , -- id - nvarchar(50)
          N'张三' , -- UILoginName - nvarchar(50)
          N'1234' , -- UICode - nvarchar(50)
          N'宝华' , -- UICustomerType - nvarchar(50)
          0 , -- VersionNo - int
          NEWID() , -- TransactionID - nvarchar(50)
          N'初始化脚本' , -- CreateBy - nvarchar(50)
          GETDATE() , -- CreateOn - datetime
          N'初始化脚本' , -- UpdateBy - nvarchar(50)
          GETDATE() , -- UpdateOn - datetime
          0  -- IsDeleted - int
        )
          
SELECT * FROM SYS_Code
/****** Script for SelectTopNRows command from SSMS  ******/
	SELECT *
  FROM [XiangXi].[dbo].[V_Table_Comments]
