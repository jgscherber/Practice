"""
We shall say that an n-digit number is pandigital if it makes use of all
the digits 1 to n exactly once; for example, the 5-digit number, 15234,
is 1 through 5 pandigital.

The product 7254 is unusual, as the identity, 39 x 186 = 7254, containing
multiplicand, multiplier, and product is 1 through 9 pandigital.

Find the sum of all products whose multiplicand/multiplier/product
identity can be written as a 1 through 9 pandigital.

HINT: Some products can be obtained in more than one way so be sure to
only include it once in your sum.
"""
import cProfile
# length  of product + length of 2 multipliers = n

# avoid duplicates with a set
# a < 10 ; b < 10000
# 10 < a < 100 ; b < 1000
# 100 < a < 1000 ; b < 100
# 1000 < a < 10000 ; b < 10

# slightly faster than the sorting and checking for equality (~0.5 s)
def pandigital_check(a,b,prod):
    number = list(str(a) + str(b) + str(prod))
    if len(number) != 9:
        return False
    for char in ['1','2','3','4','5','6','7','8','9']:
        if char not in number:
            return False
    return True
    
def main():
    products = set()
    for a in range(1,10000):
        if a < 10:
            for b in range(1,10000):
                if pandigital_check(a,b,a*b):
                    products.add(a*b)
        elif a < 100:
            for b in range(1,1000):
                if pandigital_check(a,b,a*b):
                    products.add(a*b)
        elif a < 1000:
            for b in range(1,100):
                if pandigital_check(a,b,a*b):
                    products.add(a*b)
        else:
            for b in range(1,10):
                if pandigital_check(a,b,a*b):
                    products.add(a*b)
    print(sum(products))
cProfile.run('main()')
