"""

Too messy to paste here: https://projecteuler.net/problem=27

"""

from useful import *
# -1000 < a < 1000, -1000 < b < 1000

# brute force would take a lot of checks...
arange = 1000
# b has to be prime for n=0 to be true
brange1 = primeList(1000)
brange = []
for b in brange1:
    brange.append(-b)
    brange.append(b)

sol = []
maxn=0
for a in range(-arange+1,arange):
    #print(a)
    for b in brange:
       n=0
       while isPrime(abs(n**2+a*n+b)):
           n +=1
       if n > maxn:
           maxn = n-1
           sol = [a,b]

# n^2 - 61n + 971
# 0 <= n <= 70

