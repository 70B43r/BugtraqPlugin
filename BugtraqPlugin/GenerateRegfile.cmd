@echo off
rem
rem Project            : Tortoise Bugtraq Plugin
rem Module:            : BugtraqPlugin
rem Description        : Main plugin class.
rem 
rem Repository         : $URL$
rem Last changed by    : $LastChangedBy$
rem Revision           : $LastChangedRevision$
rem Last Changed       : $LastChangedDate$
rem Author             : $Author$
rem
rem Id:                : $Id$
rem
rem Copyright:         (c) 2010 Torsten Bär
rem
rem Published under the MIT License. See license.txt or http:remwww.opensource.org/licenses/mit-license.php.
rem

setlocal

if exist ../Build/Debug/BugtraqPlugin.dll (
echo generating regfile for debug build

regasm ../Build/Debug/BugtraqPlugin.dll /codebase /regfile:BugtraqPlugin_Debug.reg /silent

echo. >> BugtraqPlugin_Debug.reg
echo [HKEY_CLASSES_ROOT\CLSID\{3F568A2A-3AAC-4B0D-B187-F1240F931152}\Implemented Categories\{3494FA92-B139-4730-9591-01135D5E7831}] >> BugtraqPlugin_Debug.reg

echo regfile for debug build is BugtraqPlugin_Debug.reg
) else (
echo debug build not found
)

if exist ../Build/Release/BugtraqPlugin.dll (
echo generating regfile for release build

regasm ../Build/Release/BugtraqPlugin.dll /codebase /regfile:BugtraqPlugin_Release.reg /silent

echo. >> BugtraqPlugin_Release.reg
echo [HKEY_CLASSES_ROOT\CLSID\{3F568A2A-3AAC-4B0D-B187-F1240F931152}\Implemented Categories\{3494FA92-B139-4730-9591-01135D5E7831}] >> BugtraqPlugin_Release.reg

echo regfile for release build is BugtraqPlugin_Release.reg
) else (
echo release build not found
)

endlocal

sleep 2