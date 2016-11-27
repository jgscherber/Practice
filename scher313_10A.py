# Jacob Scherber
# Sec. 24

# super class with only color attribute
class Vehicle(object):
    def __init__(self, color = ""):
        self.__color = color
    def getColor(self):
        return self.__color
    def setColor(self, new):
        self.__color = new
        
# subclasses with door attributes
class Car(Vehicle):
    def __init__(self, color = "", doors = 4):
        # initilize superclass
        Vehicle.__init__(self, color)
        self.__doors = doors
    def getNumDoors(self):
        return self.__doors
    def setNumDoors(self, new):
        self.__doors = new

class SUV(Vehicle):
    def __init__(self, color = "", doors = 4):
        Vehicle.__init__(self, color) # this line
        self.__doors = doors
    def getNumDoors(self):
        return self.__doors
    def setNumDoors(self, new):
        self.__doors = new

class Truck(Vehicle):
    def __init__(self, color = "", doors = 2):
        Vehicle.__init__(self, color) # this line
        self.__doors = doors
    def getNumDoors(self):
        return self.__doors
    def setNumDoors(self, new):
        self.__doors = new

