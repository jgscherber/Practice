"""
A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

a^2 + b^2 = c^2
For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.
"""

# a = a'^2
# b = b'^2
# c = c'^2

# a, b, and c all need to be perfect square and less than 998 (a + 1 + 1)
# use floats with 4 decimals of precision

# a + b +c = 1000
# a^2 + b^2 = c^2
number = 1000
def find_triple(number):
    for n1 in range(1,number):
        number2 = number-n1
        for n2 in range(1,number):
            number3 = number2 - n2
            for n3 in range(1,number):
                #print(n1+n2+n3,n1**2+n2**2,n3**2)
                if (n1+n2+n3 > 1000) or \
                (n1**2 + n2**2 < n3**2):
                    break
                if (n1+n2+n3 == 1000) and \
                (n1**2 + n2**2 == n3**2):
                    return n1,n2,n3
    

fn1,fn2,fn3 = find_triple(number)
print(fn1,fn2,fn3)
print(fn1*fn2*fn3)
                                  
# answer
#(200, 375, 425)
#31875000
