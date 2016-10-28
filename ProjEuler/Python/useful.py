"""
___Sieve of Eratosthenes____
o 1 is not prime
o All primes except 2 are odd
o All primes greater than 3 can be written as 6k+/-1
o Any number can only have one primefactor greater than sqrt(n) (itself)
"""
import math

def isPrime(n):
    # 1 is not prime
    if n==1:
        return False
    # 2 and 3 are prime
    elif n<4:
        return True
    # no even primes >2
    elif n%2==0:
        return False
    # previes test excluded 4, 6, and 8
    elif n<9:
        return True
    # not multiples of 3
    elif n%3==0:
        return False
    else:
        # only prime factor great than sqrt(n) is itself
        r = math.floor(n**(0.5))
        # start at 5: 5=6k-1, k=1
        f = 5
        while f<=r:
            if n%f==0:
                return False
            # 6k+1
            if n%(f+2)==0:
                return False
            f+=6
    return True
