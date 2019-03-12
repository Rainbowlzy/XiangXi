DECLARE @t NVARCHAR(MAX)= N'';
DECLARE @cnt INT = 0;
DECLARE @total INT= 0;
SELECT  @total = COUNT(1)
FROM    sys.databases
WHERE name NOT IN('tempdb','master','model','msdb');

DECLARE c_cursor CURSOR GLOBAL FOR SELECT 'backup database ['+name+'] to disk=''D:\db_back\'+name+'_'+REPLACE(SYSTEM_USER,'\','_')+'_'+convert(varchar, getdate(), 112)+'.bak''' FROM sys.databases WHERE name NOT IN('tempdb','master','model','msdb');

OPEN c_cursor

WHILE @cnt < @total
    BEGIN
		FETCH NEXT FROM c_cursor INTO @t; 
        PRINT @t
        EXEC sys.sp_executesql @t,N''
        SET @cnt = @cnt + 1;
    END;
    

CLOSE c_cursor
DEALLOCATE c_cursor;
