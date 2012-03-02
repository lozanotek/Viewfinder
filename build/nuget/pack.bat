RMDIR /S /Q ..\binaries
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ..\..\src\Viewfinder.sln -t:Clean
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ..\..\src\Viewfinder.sln -p:Configuration=Debug

xcopy /Y ..\binaries\*.* Viewfinder\lib
xcopy /Y /S /I ..\..\src\Viewfinder\*.cs Viewfinder\src\Viewfinder
nuget pack Viewfinder/Viewfinder.nuspec -symbols

