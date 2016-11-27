# Jacob Scherber
# Sec. 24

# super class with only color attribute

class FootMeasure(object):
    def __init__(self, feet=0, inches=0):
        # use int conversion instead of integer div to force rounding toward zero
        # (instead of strictly floor)
        self.feet = int(feet + inches / 12)
        # handle negative incheas with modulus
        if inches<0:
            self.inches = (-inches)%12
            self.inches = -self.inches
        else:
            self.inches = inches%12
    def __repr__(self):
        if self.inches == 0 and self.feet != 0:
            return str(self.feet) + " ft."
        elif self.feet == 0 and self.inches != 0:
            return str(self.inches) + " in."
        return str(self.feet) + " ft. " + str(self.inches) + " in."
    def __add__(self, other):
        return FootMeasure(inches = (self.feet*12) + self.inches \
                           + (other.feet*12) + other.inches)
    def __sub__(self, other):
        # need to work on this - using a print statement still returns None
        if ((self.feet*12) + self.inches) - ((other.feet*12) + other.inches) \
           < 0:
##            raise ValueError("Error: subtraction results in a negative value of " \
##                  + str(FootMeasure(inches = ((self.feet*12) + self.inches) \
##                           - ((other.feet*12) + other.inches))))
           pass
        else:
            return FootMeasure(inches = ((self.feet*12) + self.inches) \
                           - ((other.feet*12) + other.inches))

    def __lt__(self, other):
        return (self.feet*12) + self.inches \
                           < (other.feet*12) + other.inches
    def __gt__(self, other):
        return (self.feet*12) + self.inches \
                           > (other.feet*12) + other.inches
    def __eq__(self, other):
        return (self.feet*12) + self.inches \
                           == (other.feet*12) + other.inches
def testMeasure(): 
    meas1 = FootMeasure()
    meas2 = FootMeasure(feet = 5)
    meas3 = FootMeasure(feet = 5, inches = 8)
    meas4 = FootMeasure(inches = 68)
    meas7 = FootMeasure(inches = 5)
    print(meas2)
    print(meas4)
    print(meas7)
    print()
    meas5 = meas2 + meas3
    print(meas5)
    print(meas3 + meas4)
    print(meas3 - meas4)
    # broken subtraction
    meas6 = meas2 - meas3
    print(meas6)
    print()
    print(meas2 < meas3)
    print(meas2 > meas3)
    print(meas3 < meas2)
    print(meas3 > meas2)
    meas8 = FootMeasure(feet = 5)
    print(meas2 == meas8)
    print(meas2 == meas3)
    
testMeasure()
