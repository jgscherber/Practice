# https://projecteuler.net/problem=28

"""
Starting with the number 1 and moving to the right in a clockwise direction a
5 by 5 spiral is formed as follows:

21 22 23 24 25
20  7  8  9 10
19  6  1  2 11
18  5  4  3 12
17 16 15 14 13

It can be verified that the sum of the numbers on the diagonals is 101.

What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral
formed in the same way?
"""
# bottom-left to top-right: 
# whole seq. 1 3 5 7 9 13 17 21 25
# bottom-right to top-left: f(n) = n^2-n+1

size = 1001
n=1
sum1 = 0
sum2 = -1
add = 0
diag2 = 1
incr = 4
while(diag2 <= size**2):
##    print("n: ",n)
##    print("d1: ",n**2-n+1)
##    print("d2: ",diag2)
    sum1 += n**2-n+1
    sum2 += diag2
    if add<2:
        add+=1
    else:
        incr += 4
        add = 1
    diag2 += incr
    n+=1

print(sum1 + sum2)

