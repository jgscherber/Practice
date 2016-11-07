"""
A perfect number is a number for which the sum of its proper divisors is
exactly equal to the number. For example, the sum of the proper divisors of 28
would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

A number n is called deficient if the sum of its proper divisors is less than
n and it is called abundant if this sum exceeds n.

As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest
number that can be written as the sum of two abundant numbers is 24. By
mathematical analysis, it can be shown that all integers greater than 28123
can be written as the sum of two abundant numbers. However, this upper limit
cannot be reduced any further by analysis even though it is known that the
greatest number that cannot be expressed as the sum of two abundant numbers is
less than this limit.

Find the sum of all the positive integers which cannot be written as the sum
of two abundant numbers.
"""
def SumOfProperDiv(n):
    # floor of the square root
    r = (n**(0.5))//1
    
    if r**2==n:
        tot = 1+r
        r = r-1
    else:
        tot = 1
    if n % 2 == 1:
        f = 3
        step = 2
    else:
        f = 2
        step = 1
    while f<=r:
        if n % f == 0: tot = tot + f + n//f
        f += step
    return tot

def generate_abundants(n):
    abundant = []
    # accidentally had 1 as an abundent, was messing up calc
    for i in range(2,n+1):
        if SumOfProperDiv(i) > i:
            abundant.append(i)
    return abundant

def calculate_sum(abundant, n):
    # use set to prevent duplicate entries in adundent_sums w/o doing
    # explicit checking
    abundant_sums = set()
    
    for j in abundant:
        for k in abundant:
            if j+k <= 28123:
                abundant_sums.add(j+k)
            else:
                break
    # return the total of all the intergers below 28123 minus the sum of the
    # abundant pairs
    return(n*(n+1))/2 - sum(abundant_sums)

