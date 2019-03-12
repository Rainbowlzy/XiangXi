
@mkdir D:\db_back
@osql -S . -E -i backup_db.sql

:start
@git pull
@goto start