echo ׼����ʼ���ɱ��

set homeford=%cd%
echo %homeford%
cd..
cd..
set workpath=%cd%
cd "%homeford%"

echo ����Ŀ���ļ���
set DstTableFolder=%workpath%\Game\Tables
set SrcTableFolder=%workpath%\Plugins\CreateTableTool\SrcTXT


echo �뽫txt�����뵽%SrcTableFolder%Ŀ¼��

echo ��ʼ���ɴ����ļ�...

if %PROCESSOR_ARCHITECTURE%==x86 goto p1 else goto p2

:p2
echo x64������...
PlistTableCode.exe -d:%SrcTableFolder% -CSharp
goto ep

:p1
echo x86������...
PlistTableCode.exe -d:%SrcTableFolder% -CSharp
goto ep

:ep
echo ����*.cs
copy /Y .\CodeTable\CSharp\*.cs "%DstTableFolder%"\
echo �뼰ʱ�����Ŀ¼Add�ļ�����Ȼ�ͱ಻������ 

pause
