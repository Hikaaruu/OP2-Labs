import math


class TPrism:
    def __init__(self, sideLength, height, baseSidesCount):
        self._height = height
        self._sideLength = sideLength
        self._baseSidesCount = baseSidesCount

    def SurfaceArea(self):
        angleRad = (180 / self._baseSidesCount) * math.pi / 180
        baseArea = (self._baseSidesCount * math.pow(self._sideLength, 2)) / (4 * math.tan(angleRad))
        sideFaceArea = self._height * self._sideLength
        return 2 * baseArea + sideFaceArea * self._baseSidesCount

    def Volume(self):
        angleRad = (180 / self._baseSidesCount) * math.pi / 180
        baseArea = (self._baseSidesCount * math.pow(self._sideLength, 2)) / (4 * math.tan(angleRad))
        return baseArea * self._height

    @property
    def height(self):
        return self._height

    def sideLength(self):
        return self._sideLength

    def baseSidesCount(self):
        return self._baseSidesCount


class TPrism3(TPrism):
    def __init__(self, sideLength, height):
        TPrism.__init__(self, sideLength, height, 3)


class TPrism4(TPrism):
    def __init__(self, sideLength, height):
        TPrism.__init__(self, sideLength, height, 4)

