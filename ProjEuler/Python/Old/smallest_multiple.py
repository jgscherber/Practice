"""
2520 is the smallest number that can be divided by each of the numbers from
1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the
numbers from 1 to 20?
"""

def even_twenty():
    #divisors = [x for x in range(2,11)]
    divisors = [11,12,13,14,15,16,17,18,19,20]
    #print(divisors)
    test = 1
    while True:
        remainders = [test%x for x in divisors]
        
        if sum(remainders) == 0:
            break
        test += 1
    return test

print(even_twenty())
#Answer: 232792560
