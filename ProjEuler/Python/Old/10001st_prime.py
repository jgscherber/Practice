"""
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that
the 6th prime is 13.

What is the 10 001st prime number?
"""

def prime_finder(number):
    current = 6
    prime = 13
    while current < number:
        prime += 1
        primeB = True
        for i in range(2,prime):
            if prime%i==0:
                primeB=False
                break
            
        if primeB:
            current += 1
    return prime

print(prime_finder(10001))
#Answer: 104743            
        
                
