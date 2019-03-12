echo begin----------------------------------

set tt=ttlist1.txt
IF NOT EXIST %tt% dir /s /b *.tt>%tt%
IF EXIST t4_generator_job.bat DEL /Q t4_generator_job.bat
for /f %%f in (%tt%) do (
	start cmd /c "gen_t4 %%f"
)
@rem IF EXIST t4_generator_job.bat t4_generator_job.bat
@rem "E:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe" XiangXi.sln /Build

echo end----------------------------------