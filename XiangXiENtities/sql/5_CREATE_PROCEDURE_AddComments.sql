USE [XiangXi]
GO
if exists (select name from sys.objects where name='AddComments') DROP PROCEDURE AddComments
GO
/****** Object:  StoredProcedure [dbo].[AddComments]    Script Date: 04/07/2018 23:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		路正遥
-- Create date: 2018-3-31
-- Description:	编写字段注释
-- =============================================
CREATE PROCEDURE [dbo].[AddComments]

	@table nvarchar(200)=N'',
	@column nvarchar(200)=N'',
	@comments nvarchar(4000)=N''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	EXEC sys.sp_addextendedproperty 
		@name=N'MS_Description'
		,@value=@comments 
		,@level0type=N'SCHEMA'
		,@level0name=N'dbo'
		,@level1type=N'TABLE'
		,@level1name=@table
		,@level2type=N'COLUMN'
		,@level2name=@column
END
GO