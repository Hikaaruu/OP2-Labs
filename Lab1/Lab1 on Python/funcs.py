import keyboard

def getRows():
    print("Enter text (press Home + Enter to continue):")
    rows = []
    while not keyboard.is_pressed('home'):
        row = input()
        rows.append(row)
    return rows


def writeInFile(lines,fileName):
    file = open(fileName, "w+")
    for i in range(0,len(lines)):
        file.write(lines[i])
        if  i != len(lines)-1:
            file.write("\n")
    file.close()


def deleteDublicated(lines):
    result = []
    miss = 0
    for i in lines:
        if i not in result:
            result.append(i)
        else:
            miss+=1

    return result,miss

def createOuptup(fileName,lines,amount):
    newlines= []
    if (amount>len(lines) or amount<0):
        print("This number can't be negative or less than amount of all raws \n")
        return
    i = len(lines) - amount
    while i<len(lines):
        newlines.append(lines[i])
        i+=1
    results,miss = deleteDublicated(newlines)
    print("")
    writeInFile(results, "output.txt")
    return miss


def printFile(fileName):
    file = open(fileName, 'rt')
    text = file.read()
    file.close()
    print(fileName+" :\n"+text+"\n")
    return

