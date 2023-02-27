chcp 65001

SET Configuration=Release
SET Framework=net7.0
SET Runtime=win10-x64

dotnet publish -c %Configuration% -f %Framework% -r %Runtime% /p:PublishSelfContained=true /p:RuntimeIdentifier=win10-x64 /p:TargetFramework=net7.0 /p:PublishSingleFile=True /p:IncludeAllContentForSelfExtract=True

@echo off
if NOT ["%errorlevel%"]==["0"] PAUSE
