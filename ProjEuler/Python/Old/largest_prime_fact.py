"""
The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?
"""
import math
# number is too large to run
# Python 32 bit largest: 2^31 - 1 = 2147483647
# Python 64 bit largest: 2^63 - 1 = 9223372036854775807
# couldresize to decimal (e.g. 600851.475143) --> rounding is too messy...

def find_primes(value):
    prime_fac = []
    primeB = True
    for prime in value:
        for i in range(2,prime):
            if prime%i==0:
                primeB=False
                break
        if primeB:
             prime_fac.append(prime)
    return max(prime_fac)


def find_factors(value):
    sqrted = int(math.ceil(math.sqrt(value)))
    factors = []
    while value != 1:
        for i in range(2,sqrted+1):
            if value%i == 0:
                factors.append(i)
                value = value/i
                break
        
    return factors
                
#test = 13195    
test = 600851475143
factors = find_factors(test)
print(find_primes(factors))

