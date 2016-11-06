"""
n! means n x (n − 1) x ... x 3 x 2 x 1

For example, 10! = 10 x 9 x ... x 3 x 2 x 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!
"""

def fact(n):
    if n == 0:
        return 1
    else:
        return n * fact(n-1)

ans = sum([ int(x) for x in str(fact(100))])
print(ans)

