import pickle
from datetime import time
from os.path import exists
import os


CONST_PATH = "records.dat"
dayStart = time(9,0)
dayEnd = time(17,0)
addInfoAboutFinish = False
timePeriodsList = []

class TimePeriod :
    def __init__(self, tStart, tEnd):
        self.tStart = tStart
        self.tEnd = tEnd


def ClearOrContinue():
    if (exists(CONST_PATH)):
        print("records.bat already exists. Clear it (1) or continue populating (2) ?   (1/2) ")
        ans = int(input())
        print()
        if (ans==1):
            os.remove(CONST_PATH)
        else:
            global addInfoAboutFinish
            addInfoAboutFinish = True
            AddExistingRecordsToList()



def AddExistingRecordsToList():
    with open(CONST_PATH, 'rb') as file:
        while (True):
            try:
                surname = pickle.load(file)
            except Exception:
                break

            tStart = pickle.load(file)
            # tStart = time(int(stStart[0:2]), int(stStart[3:]))

            tEnd = pickle.load(file)
            # tEnd = time(int(stEnd[0:2]), int(stEnd[3:]))

            timePeriodsList.append(TimePeriod(tStart,tEnd))

def PrintRecordings():
    print("All records :")
    print()
    with open(CONST_PATH, 'rb') as file:
        while (True):
            try:
                surname = pickle.load(file)
            except Exception:
                break
            tStart = pickle.load(file)
            tEnd = pickle.load(file)

            print("Surname: " + surname)
            print("Service start time: " + str(tStart.strftime("%H:%M")))
            print("Service end time: " + str(tEnd.strftime("%H:%M")))
            print()


def MakeRecord(surname, tStart, tEnd ):
    with open(CONST_PATH,'ab') as file:
        pickle.dump(surname,file)
        pickle.dump(tStart, file)
        pickle.dump(tEnd, file)

def Populate() :
    while (True):
        overlaping = False
        global  addInfoAboutFinish
        if(addInfoAboutFinish):
            print("Enter a surname of your client (type \"finish\" to finish) :")
        else:
            print("Enter a surname of your client :")
        surname = input()
        if (surname=="finish"):
            break
        print()

        print ("Enter a customer arrival time (in format hh:mm) :")
        stStart = input()
        try:
            tStart = time(int(stStart[0:2]), int(stStart[3:]))
        except Exception:
            print()
            print("Incorrect time format. Record could not be added!")
            print()
            continue
        print()

        print ("Enter a customer service end time (in format hh:mm) :")
        stEnd = input()
        try:
            tEnd = time(int(stEnd[0:2]), int(stEnd[3:]))
        except Exception:
            print()
            print("Incorrect time format. Record could not be added!")
            print()
            continue
        print()

        if (tEnd<=tStart):
            print("Start time cannot be greater then or equal to end time! Record could not be added!")
            print()
            continue

        if (tStart<dayStart or tEnd>dayEnd):
            print("Working day starts at 09:00 and ends at 17:00. Record could not be added! ")
            print()
            continue

        for span in timePeriodsList:
            if (tStart< span.tEnd and span.tStart < tEnd):
                print("This time period overlaps the existing one. Record could not be added!")
                overlaping = True
                break

        if (overlaping):
            continue

        timePeriodsList.append(TimePeriod(tStart, tEnd))
        MakeRecord(surname, tStart, tEnd)
        addInfoAboutFinish = True

def FindAndPrintGaps():
    print()
    print("Time when manager was free :")
    print()
    sortedList = timePeriodsList
    sortedList.sort(key= lambda TimePeriod: TimePeriod.tStart)
    freeTime = False
    count = 0
    position = dayStart
    for period in sortedList:
        if (position < period.tStart):
            count+=1
            print(str(position.strftime("%H:%M")) + " - " + str(period.tStart.strftime("%H:%M")))
        position = period.tEnd

    if (sortedList[-1].tEnd < dayEnd):
        count+=1
        print(str(sortedList[-1].tEnd.strftime("%H:%M")) + " - " + str(dayEnd.strftime("%H:%M")))

    print()
    print("A total amout of gaps : " + str(count))





