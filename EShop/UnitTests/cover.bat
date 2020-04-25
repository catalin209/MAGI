@ECHO OFF

REM AltCover & ReportGenerator are in the csproj
REM set altcover_version=5.3.675
REM dotnet add package AltCover -v %altcover_version%
set repgen_version=4.3.0
REM dotnet add package ReportGenerator -v %repgen_version%

set cdir=coverage
set cfile=coverage.xml

REM opencover version 4.7.922
REM set dotnet=%ProgramFiles%\dotnet\dotnet.exe
REM set opencover=%userprofile%\.nuget\packages\opencover\%v1%\tools\OpenCover.Console.exe
REM rem %opencover% -target:"%dotnet%" -targetargs:"test UnitTests.csproj" -oldstyle -output:coverage/coverage.xml
REM %opencover% -target:"%dotnet%" -targetargs:"test UnitTests.csproj" -oldstyle -output:coverage/coverage.xml -searchdirs:./bin/Debug/netcoreapp2.2;bin\Debug\netcoreapp2.2\ -showunvisited

dotnet build UnitTests.csproj

dotnet test -v normal --no-build ^
/p:AltCover=true /p:AltCoverXmlReport=%cdir%/%cfile% ^
/p:AltCoverFailFast=true ^
/p:AltCoverShowSummary=true ^
/p:AltCoverForce=true ^
/p:AltCoverAttributeFilter=ExcludeFromCodeCoverage ^
/p:AltCoverAssemblyExcludeFilter="UnitTests|xunit.runner.visualstudio.dotnetcore.testadapter|xunit.runner.utility.netcoreapp10|xunit.runner.reporters.netcoreapp10"

set reportgen=%userprofile%\.nuget\packages\reportgenerator\%repgen_version%\tools\net47\ReportGenerator.exe
%reportgen% -reports:%cdir%/%cfile% -targetdir:%cdir% -verbosity:Error
start "report" "%cdir%\index.htm" &