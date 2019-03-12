
set filename=..\deploy_ÏãÏª_%date:~,4%%date:~5,2%%date:~8,2%.zip

mkdir ..\deploy\

"D:\Program Files\Microsoft SQL Server\100\Tools\Binn\OSQL.EXE" -S . -U sa -PSa123456 -Q "BACKUP DATABASE XiangXi TO DISK='D:\XiangXi_%date:~,4%%date:~5,2%%date:~8,2%.bak'"
xcopy /Y D:\XiangXi_%date:~,4%%date:~5,2%%date:~8,2%.bak ..\deploy\

start xcopy /Y /S XiangXi\assets ..\deploy\assets
start xcopy /Y /S XiangXi\Upload ..\deploy\Upload
start xcopy /Y /S XiangXi\gen\*.js ..\deploy\gen
start xcopy /Y /S XiangXi\gen\*.html ..\deploy\gen
start xcopy /Y /S XiangXi\0_common      ..\deploy\0_common
start xcopy /Y /S XiangXi\1_index       ..\deploy\1_index
start xcopy /Y /S XiangXi\2_map         ..\deploy\2_map
start xcopy /Y /S XiangXi\3_maintain    ..\deploy\3_maintain
start xcopy /Y /S XiangXi\4_login       ..\deploy\4_login
start xcopy /Y /S XiangXi\5_specialwork ..\deploy\5_specialwork
start xcopy /Y /S XiangXi\assets        ..\deploy\assets
start xcopy /Y /S XiangXi\dist          ..\deploy\dist
start xcopy /Y /S XiangXi\hanfei        ..\deploy\hanfei
start xcopy /Y /S XiangXi\images        ..\deploy\images
start xcopy /Y /S XiangXi\menu          ..\deploy\menu
start xcopy /Y /S XiangXi\scripts       ..\deploy\scripts
start xcopy /Y /S XiangXi\src           ..\deploy\src
start xcopy /Y /S XiangXi\Upload        ..\deploy\Upload
start xcopy /Y /S XiangXi\zeroclipboard ..\deploy\zeroclipboard

"D:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe" XiangXi\XiangXi.csproj /Deploy


rem "D:\Program Files\7-Zip\7z.exe" a %filename% ..\deploy
rem xcopy /-Y %filename% "C:\Users\rainb\Desktop\"
rem xcopy /-Y %filename% "\\192.168.31.190\ShareFolder\"
rem explorer "C:\Users\rainb\Desktop\"

pause
