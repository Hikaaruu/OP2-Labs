import math
from classes import *


def tryParseInt(s, base=10, val=None):
    try:
        return int(s, base)
    except ValueError:
        return val


def tryParseDouble(s, val=None):
    try:
        return float(s)
    except ValueError:
        return val


def Input():
    m = 0
    sides = 0
    side_length = 0
    height = 0
    prisms = []

    # region validating and parsing of m
    print("Enter the amount of prisms you want to create")
    temp = input()
    while tryParseInt(temp, val=-1) == -1 or tryParseInt(temp, val=-1) <= 0:
        print("Incorrect format! Try again!")
        temp = input()
    m = tryParseInt(temp, val=-1)
    # endregion

    for i in range(m):
        # region validating and parsing of sides count
        print("Enter the amount of base sides (3 or 4)")
        temp = input()
        while tryParseInt(temp, val=-1) == -1 or (tryParseInt(temp, val=-1) != 3 and tryParseInt(temp, val=-1) != 4):
            print("Incorrect format! Try again!")
            temp = input()
        sides = tryParseInt(temp, val=-1)
        # endregion

        # region validating and parsing of base side length
        print("Enter the length of base side")
        temp = input()
        while tryParseDouble(temp, val=-1) == -1 or tryParseDouble(temp, val=-1) <= 0:
            print("Incorrect format! Try again!")
            temp = input()
        side_length = tryParseDouble(temp, val=-1)
        # endregion

        # region validating and parsing of prism height
        print("Enter the height of prism")
        temp = input()
        while tryParseDouble(temp, val=-1) == -1 or tryParseDouble(temp, val=-1) <= 0:
            print("Incorrect format! Try again!")
            temp = input()
        height = tryParseDouble(temp, val=-1)
        # endregion

        # region adding prisms to List
        if sides == 3:
            prisms.append(TPrism3(side_length, height))
        else:
            prisms.append(TPrism4(side_length, height))
        # endregion

    return prisms


def Sum(prisms):
    volumeSum = 0
    areaSum = 0
    for x in prisms:
        if x._baseSidesCount == 3:
            volumeSum += x.Volume()
        else:
            areaSum += x.SurfaceArea()
    return volumeSum, areaSum



