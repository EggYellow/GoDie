@echo off
echo 准备开始同步客户端表格

echo 设置目标文件夹
set TempTableFolder=./CreateTableTool/TmpClientDic/
set ClientTableFolder=../Game/Resources/Bundle/Table/
set PublicClientFolder=./ClientTables/

echo 请将公用文件放入到同级ClientTables目录下

echo 转化客户端txt为UTF8格式，并拷贝

"./OtherTools/TxtConvExe_Split/txtConv.exe" %TempTableFolder% %PublicClientFolder% %ClientTableFolder% -s 1000

echo 检查表格

"./OtherTools/TableChecker/table_checker.exe"

pause