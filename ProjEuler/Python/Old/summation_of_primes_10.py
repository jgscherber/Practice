"""
The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.
"""

# don't need to check all numbers, only all primes less than the current
# other numbers will be multiples of prime factors
def find_primes(value):
    prime_fac = [2]
    for prime in range(3,value):
        primeB = True
        for i in prime_fac:
            # if a prime is greater than square root of the value, it doesn't
            # need to be checked
            if i <= (prime**(0.5)):
                if prime%i==0:
                    primeB=False
                    break
            else:
                break
        if primeB:
            prime_fac.append(prime)
  
    return prime_fac


factors = find_primes(2000000)

print(sum(factors))
# answer: 142913828922
# ... 1 isn't prime, D'oh!
