"""
A unit fraction contains 1 in the numerator. The decimal representation of the
unit fractions with denominators 2 to 10 are given:

1/2	= 	0.5
1/3	= 	0.(3)
1/4	= 	0.25
1/5	= 	0.2
1/6	= 	0.1(6)
1/7	= 	0.(142857)
1/8	= 	0.125
1/9	= 	0.(1)
1/10	= 	0.1

Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be
seen that 1/7 has a 6-digit recurring cycle.

Find the value of d < 1000 for which 1/d contains the longest recurring cycle
in its decimal fraction part.
"""

from useful import *

# https://en.wikipedia.org/wiki/Longest_repeated_substring_problem
# Used walkthrough at http://blog.dreamshire.com/project-euler-26-solution/

# Fermat's Little Theorem: 1/d has a cycle of n digits if (10^n - 1) mod d = 0
# if d is prime

# d has a cycle of n digits if n is the smallest positive integer satisfying
# 10^n – 1 mod d = 0, for d co-prime to 10. (So d cannot be 2 or 5)

# d has to be a prime
primes = primeList(1000)
print("Prime list generated...")
for d in reversed(primes[10:-1]):
    
    period = 1
    # pow(x,y,z) == x^y % z
    # != 1 to account for the -1 in Femera's little (instead of 0)
    while pow(10,period,d)!=1:
        period += 1
        #print(pow(10,period,d))
    if (d-1) == period: break

print(d)


        
    






