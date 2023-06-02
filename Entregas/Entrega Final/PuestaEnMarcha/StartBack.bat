@echo off
setlocal

REM Get the current directory
set "currentDir=%~dp0"

REM Build the path to the .exe file
set "exePath=%currentDir%src\backend\ArenaGestor.API.exe"

REM Run the .exe file
"%exePath%"

endlocal