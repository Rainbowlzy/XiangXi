
dir /s /b *.sql > all_sql_files
for /f "delims=" %%f in (all_sql_files) do (
	@rem SQLCMD -E -dXiangXi -i%%f>>log
	osql -E -dXiangXi -i%%f>>log
)
type log
pause