:: June 2012 y.s.

echo off
color f0

cd /d "%~dp0"

:: Create settings.txt
echo Configration
echo Default Wattage is 280.
echo Default Pirce is 0.57.
echo Just press enter if you want use the default value.
echo.
set /p wattage=Wattage of your PC: 
set /p price=Pirce of electricity: 
del "settings.txt"
if "%wattage%"=="" (
	set wattage=280
)
if "%price%"=="" (
	set price=0.57
)
echo wattage = %wattage% >> "settings.txt"
echo price = %price% >> "settings.txt"
echo.

:: Install service.

set p="%windir%\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe"

echo Choose a number:
echo 1. Install;
echo 2. Stop;
echo 3. Start;
echo 4. Uninstall;
echo 5. Exit.

set /p opt=Choice: 

if "%opt%"=="1" (
	echo Begin installing...
	%p% "System_usage_recorder.exe"
	sc start System_usage_recorder
) 
if "%opt%"=="2" (
	echo Stop...
	sc stop System_usage_recorder
) 
if "%opt%"=="3" (
	echo Starting...
	sc start System_usage_recorder
) 
if "%opt%"=="4" (
	echo Begin uninstalling...
	%p% -u "System_usage_recorder.exe"
)

pause