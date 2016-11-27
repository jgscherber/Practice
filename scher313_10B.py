class Pet(object):
    def __init__(self, name = "",sex="",weight=0,age=0,adoptFee=0,fixed=False):
        self.__name = name
        self.__sex = sex
        self.__weight = float(weight)
        self.__age = float(age)
        self.__adoptFee = float(adoptFee)
        self.__fixed = fixed
    def getName(self):
        return self.__name
    def getSex(self):
        return self.__sex
    def getWeight(self):
        return self.__weight
    def getAge(self):
        return self.__age
    def getAdoptionFee(self):
        return self.__adoptFee
    def getNeuteredOrSpayed(self):
        return self.__fixed
    def setName(self,nName):
        self.__name = nName
    def setSex(self,nSex):
        self.__sex = nSex
    def setWeight(self,nWeight):
        self.__weight = nWeight
    def setAge(self,nAge):
        self.__age = nAge
    def setAdoptionFee(self,nAdoptionFee):
        self.__adoptFee = nAdoptionFee
    def setNeuteredOrSpayed(self,nFixed):
        self.__fixed = nFixed
    def Display(self):
        print("Name:\t\t\t" + self.__name + "\nSex:\t\t\t" + self.__sex \
              + "\nWeight:\t\t\t" + str(self.__weight) + " lbs\nAge:\t\t\t" \
              + str(self.__age) + "yrs\nAdoption Fee:\t\t$ " \
              + str(self.__adoptFee) + "\nNeut/Spayed:\t\t" + str(self.__fixed))

class Cat(Pet):
    def __init__(self, name = "",sex="",weight=0,age=0,adoptFee=0,fixed=False \
                 ,declawed = False, hairLength = "long"):
        Pet.__init__(self, name,sex,weight,age,adoptFee,fixed)
        self.__declawed = declawed
        self.__hairLength = hairLength
    def getDeclawed(self):
        return self.__declawed
    def setDeclawed(self, nClaw):
        self.__declawed = nClaw
    def getHairLength(self):
        return self.__hairLength
    def setHairLength(self, nHair):
        self.__hairLength = hairLength
    def Display(self):
        print("Pet:\t\t\tCat")
        Pet.Display(self)
        print("Declawed:\t\t" + str(self.__declawed) + "\nHair Length:\t\t" \
              + self.__hairLength)


class Dog(Pet):
    def __init__(self, name = "",sex="",weight=0,age=0,adoptFee=0,fixed=False \
                 ,breed = "", kidFriend = False):
        Pet.__init__(self, name,sex,weight,age,adoptFee,fixed)
        self.__breed = breed
        self.__kidFriend = kidFriend
    def getBreed(self):
        return self.__breed
    def setBreed(self, nBreed):
        self.__breed = nBreed
    def getChildFriendly(self):
        return self.__kidFriend
    def setChildFriendly(self,nKid):
        self.__kidFriend = nKid
    def Display(self):
        print("Pet:\t\t\tDog")
        Pet.Display(self)
        print("Breed:\t\t\t" + self.__breed + "\nKid Friendly:\t\t" \
              + str(self.__kidFriend))
                
class Rabbit(Pet):
    def __init__(self, name = "",sex="",weight=0,age=0,adoptFee=0,fixed=False \
                 ,breed = "", color=""):
        Pet.__init__(self, name,sex,weight,age,adoptFee,fixed)
        self.__breed = breed
        self.__color = color
    def getBreed(self):
        return self.__breed
    def setBreed(self, nBreed):
        self.__breed = nBreed
    def getColor(self):
        return self.__color
    def setColor(self,nColor):
        self.__color = nColor
    def Display(self):
        print("Pet:\t\t\tRabbit")
        Pet.Display(self)
        print("Breed:\t\t\t" + self.__breed + "\nColor:\t\t\t" + self.__color)



test1 = Cat("one", "M", 10, 3, 20, True,True, 'short')
test2 = Dog("two", "F", 40, 3, 20, True,"cool", False)
test3 = Rabbit("three", "M", 7, 3, 20, True,"hoppy", 'black')
