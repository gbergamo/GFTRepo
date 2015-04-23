SET TestContainerParameter=/testcontainer:GFTTest.Test/bin/Debug/GFTTest.Test.dll
%windir%\Microsoft.net\Framework\v4.0.30319\msbuild.exe GFTTest.sln /t:Rebuild /p:Configuration=Debug && mstest %TestContainerParameter%
pause