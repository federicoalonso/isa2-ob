@echo off

REM Get the current directory
set "currentDir=%~dp0"

REM Extract the drive letter and path of the current directory
for %%A in ("%currentDir%\..\..\..") do set "targetDir=%%~fA"

REM Append the remaining path
set "targetDir=%targetDir%\codigo\ArenaGestorFront"

REM Change to the target directory
cd "%targetDir%"

REM Serve the app
ng serve