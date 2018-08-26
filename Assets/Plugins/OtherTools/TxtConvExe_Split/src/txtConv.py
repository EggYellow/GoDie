
#encoding:utf-8
import os
import sys


sourcePath = sys.argv[2]
distPath = sys.argv[3]
txtFiles = os.listdir(sourcePath)
tempPath = sys.argv[1]

# 删除文件夹里的所有文件
def CleanFolder():
    if not os.path.exists(tempPath):
        return

    for root, dirs, files in os.walk(tempPath, topdown=False):
        for f in files:
			os.remove(os.path.join(root, f))
    return

def CopyDic():
	if not os.path.exists(distPath):
		return
	for root, dirs, files in os.walk(distPath, topdown=False):
		for f in files:
			if f.endswith(".txt") and f.find("-") < 0:
				open(tempPath + f, "wb").write(open(distPath + f, "rb").read())
	
# 删除文件夹里的所有文件
def CleanTargetDic(targetName):
    if not os.path.exists(distPath):
        return

    for root, dirs, files in os.walk(distPath, topdown=False):
        for f in files:
			if f.startswith(targetName[:-4]) and f.find("-") > 0 and f.endswith(".txt"):
				print f
				os.remove(os.path.join(root, f))
    return
	
def ReadTxtNames():
	retNames = [];
	for filename in txtFiles:
		pos = filename.rfind("txt")
		if pos != -1 and filename[0] != '~':
			retNames.append(filename)
	return retNames;

def ConvertTxt(filename, bSplit, lineCount):
	curTxt = open(sourcePath + filename, "r")
	curTxtByte = curTxt.read()
	curTxt.close()
	
	CleanTargetDic(filename)
		
	if bSplit:
		lines = curTxtByte.splitlines(True)
		generateTxt = None
		for i in range(0, len(lines)):
			if i % lineCount == 0:
				if i == 0:
					generateTxt = open(distPath + filename, "w+")
				else:
					generateTxt.close()
					generateTxt = open(distPath + filename[:-4] + "-" + str(i/lineCount) + ".txt", "w+")
			#print curTxtByte
			generateTxt.write(getEncodeStr(lines[i]))
		generateTxt.close()
	else:
		generateTxt = open(distPath + filename, "w+")
		generateTxt.write(getEncodeStr(curTxtByte))
		generateTxt.close()
	return
	
def getEncodeStr(word,val='utf-8'):
    if os.name=='nt':
        wtemp=u'wtemp'
        if type(word)==type(wtemp):
            disvalue=word
        else:
            disvalue=unicode(word, 'mbcs')
        if val.lower()!='utf-8':
            try:
                tdv=disvalue.encode(val)
            except:
                tdv=disvalue.encode('utf-8')
        else:
            tdv=disvalue.encode(val)
        return tdv
    else:
        return word

def BeginConvert():
	sourceTxts = ReadTxtNames();
	bSplit = False
	splitLine = 1000
	tableList = None
	print sys.argv
	print len(sys.argv)
	if len(sys.argv) > 6 and sys.argv[4] == '-s':
		splitLine = int(sys.argv[5])
		configFile = open(sys.argv[6], "r")
		tableList = configFile.readlines()
		configFile.close()
		bSplit = True
		print tableList
		
	for filename in sourceTxts:
		bConv = False
		if bSplit:
			for line in tableList:
				if filename == line.strip('\n'):
					bConv = True
		if bConv:
			ConvertTxt(filename, True, splitLine)
		else:	
			ConvertTxt(filename, False, 1000)
			
	CleanFolder()
	CopyDic()
	
BeginConvert();