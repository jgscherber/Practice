import math
##    
##def find_factors(value, primes):
##  
##    for i in reversed(primes):
##        if value%i < 0.00001:
##            return i
##            break
        
# number is too large to run
# Python 32 bit largest: 2^31 - 1 = 2147483647
# Python 64 bit largest: 2^63 - 1 = 9223372036854775807
# couldresize to decimal (e.g. 600851.475143) --> rounding is too messy...

# divide by 2, no divisor can be bigger than half

# answer per Stack Overflow --- ungoldly slow
# maybe a recursion?
def find_primes(value):
    sqrted = int(math.ceil(math.sqrt(value)))
    factors = [i for i in range(3,sqrted,2)]
    
    for i in factors:
        j = i
        while j < value:
            j += i            
            if factors.count(j) > 0:
                del factors[factors.index(j)]
    return factors

def find_top_prime(value, factors):
    for i in factors:
        if value%i==0:
            while value%i==0:
                value = int(value / i)
                if value in factors:
                    return value
    
test = 600851475143
print(find_top_prime(test, find_primes(test)))

