

import math

class Integrator:

    def __init__(self, xMin, xMax, N):
        self.xMin = xMin
        self.xMax = xMax
        self.N = N
        self.sum = 0

    def f(self, x):
        return x**2 * math.e**(-x) * math.sin(x)

    def integrate(self):
        delta_x = (self.xMax - self.xMin) / (self.N - 1)
        for i in range(0, self.N-1): # end of range is exclusive
            x_i = self.xMin + i*delta_x
            self.sum += (self.f(x_i) * delta_x)




    def show(self):
        print(self.sum)



examp = Integrator(1,3,200)
examp.integrate()
examp.show()
