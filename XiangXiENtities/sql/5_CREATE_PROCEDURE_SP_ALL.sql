USE [XiangXi];
GO
IF EXISTS ( SELECT  name
            FROM    sys.objects
            WHERE   name = 'SP_GET_ALL_LIST' )
    DROP PROCEDURE SP_GET_ALL_LIST;
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
-- =============================================
-- Author:		路正遥
-- Create date: 2018/3/17
-- Description:	查询党员列表数据
-- =============================================
CREATE PROCEDURE SP_GET_ALL_LIST
    @districtID NVARCHAR(4000) = N'' ,
    @type NVARCHAR(50) = N'' ,
    @condition NVARCHAR(4000) = N'' ,
    @search NVARCHAR(4000) = N'' ,
    @view NVARCHAR(4000) = N'' ,
    @order NVARCHAR(4000) = N'name' ,
    @asc NVARCHAR(4000) = N'asc' ,
    @offset INT = 1 ,
    @limit INT = 5 ,
    @total INT = 0 OUTPUT
AS
    BEGIN

	--参数非空
        IF ( @districtID IS NULL
             OR @districtID = ''
           )
            SET @districtID = N'';
        IF ( @type IS NULL
             OR @type = ''
           )
            SET @type = N'';
        IF ( @search IS NULL
             OR @search = ''
           )
            SET @search = N'';
        IF ( @order IS NULL
             OR @order = ''
           )
            SET @order = N'id';
        IF ( @asc IS NULL
             OR @asc = ''
           )
            SET @asc = N'';
        IF ( @offset < 1 )
            SET @offset = 1;
        IF ( @limit < 1 )
            SET @limit = 5;
	
	
	--参数防注入
        SET @districtID = REPLACE(@districtID, '''', N'');
        SET @condition = REPLACE(@condition, '''', N'');
        SET @type = REPLACE(@type, '''', N'');
        SET @search = REPLACE(@search, '''', N'');
        SET @order = REPLACE(@order, '''', N'');
        SET @asc = REPLACE(@asc, '''', N'');
	
	--处理动态sql
        DECLARE @s NVARCHAR(4000)= 1 ,
            @e NVARCHAR(4000)= 5;
        SET @s = CONVERT(NVARCHAR, @offset);
        SET @e = CONVERT(NVARCHAR, @offset + @limit - 1);
	
        DECLARE @where NVARCHAR(4000);
        DECLARE @districtpart NVARCHAR(4000) = N'';
	
        IF ( EXISTS ( SELECT    1
                      FROM      sysobjects AS o ,
                                syscolumns AS c ,
                                systypes AS t
                      WHERE     o.type IN ( 'u', 'v' )
                                AND o.id = c.id
                                AND c.xtype = t.xtype
                                AND o.name = @view
                                AND c.name = 'districtID' )
             AND @districtID <> ''
             AND @districtID IS NOT NULL
           )
            BEGIN
                SET @districtpart = @districtpart + N'(districtID like '''
                    + @districtID + '%'' or districtID=''' + @districtID
                    + ''') and ';
            END;
	
        IF EXISTS ( SELECT  1
                    FROM    sysobjects AS o ,
                            syscolumns AS c ,
                            systypes AS t
                    WHERE   o.type IN ( 'u', 'v' )
                            AND o.id = c.id
                            AND c.xtype = t.xtype
                            AND o.name = @view
                            AND c.name = 'type' )
            AND @type <> ''
            AND @type IS NOT NULL
            BEGIN
                SET @districtpart = @districtpart + N'(type=''' + @type
                    + ''') and ';
            END;
	
        SET @where = '';
        IF ( LEN(@search) > 0 ) SELECT  @where = @where + '[' + c.name
                                        + '] like ''%' + @search + '%'' or '
                                FROM    sysobjects AS o ,
                                        syscolumns AS c ,
                                        systypes AS t
                                WHERE   o.type IN ( 'u', 'v' )
                                        AND o.id = c.id
                                        AND c.xtype = t.xtype
                                        AND o.name = @view;
	
	
        IF ( @condition <> '' )
            SET @condition = SUBSTRING(@condition, 0,
                                       CHARINDEX('=', @condition)) + '='''
                + SUBSTRING(@condition, CHARINDEX('=', @condition) + 1,
                            LEN(@condition) - CHARINDEX('=', @condition))
                + '''';
	
        IF ( LEN(@condition) - CHARINDEX('=', @condition) = 2 )
            SET @condition = '';
	

        IF ( LEN(@where) > 2 ) SELECT   @where = '(' + SUBSTRING(@where, 0,
                                                              LEN(@where) - 2)
                                        + ')';
	
        IF ( LEN(@districtpart) > 0 ) SET @where = @where + @districtpart; 
        IF ( LEN(@districtpart) > 0
             AND LEN(@condition) > 0
           ) SET @where = @where + ' AND '; 
        IF ( LEN(@condition) > 0 ) SET @where = @where + @condition;
        IF ( LEN(@where) > 2 ) SET @where = ' where ' + @where;
        SET @where = 'from ' + @view + @where;
	--计算页数
        DECLARE @totalsql NVARCHAR(4000) = N'select @total = count(1) '
            + @where;
        EXEC sp_executesql @totalsql, N'@total int output', @total OUTPUT;
	
	--拉出表格
        DECLARE @sql NVARCHAR(4000) = N'
	select *
	from (select row_number() over(order by ' + @order + ') r,
	*
	' + @where + ') t
	where 
	t.r BETWEEN ' + @s + ' AND ' + @e + '
	order by ' + @order + ' ' + @asc + ' ';
	
        PRINT @sql;
        SET NOCOUNT ON;
        EXEC sp_executesql @sql;
	
	
        SET NOCOUNT OFF;
	
    END;
GO

DECLARE @RC INT;
DECLARE @districtID NVARCHAR(4000);
DECLARE @type NVARCHAR(4000)= '困难户关爱';
DECLARE @condition NVARCHAR(4000)= 'MCCaption=''''';
DECLARE @search NVARCHAR(4000);
DECLARE @view NVARCHAR(4000);
DECLARE @order NVARCHAR(4000);
DECLARE @asc NVARCHAR(4000);
DECLARE @offset INT;
DECLARE @limit INT;
DECLARE @total INT;
SET @districtID = 'D1005031612';
SET @view = 'MenuConfiguration';
SET @limit = 10;
SET @offset = 0;

EXECUTE @RC = [XiangXi].[dbo].[SP_GET_ALL_LIST] @districtID, @type, @condition,
    @search, @view, @order, @asc, @offset, @limit, @total OUTPUT;
GO



