"""
2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 2^1000?

"""

# import isPrime(n) functions
"""
from useful import *

exp = 15
primes = []
for i in range(exp):
    if isPrime(i): primes.append(i)

number = 1
for p in primes:
"""

# Python don't care about your large integers!
number = str(2**1000)
total = 0
for i in number:
    total+=int(i)
print(total)
# 1366
