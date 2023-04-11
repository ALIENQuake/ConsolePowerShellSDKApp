chcp 65001

SET Configuration=Release
SET Framework=net8.0
SET Runtime=win10-x64

dotnet clean -c %Configuration% -f %Framework% -r %Runtime% 

dotnet publish -v d -c %Configuration% -f %Framework% -r %Runtime% /p:PublishSelfContained=true /p:PublishSingleFile=True /p:IncludeAllContentForSelfExtract=True

@echo off
if NOT ["%errorlevel%"]==["0"] PAUSE
