"""
Let d(n) be defined as the sum of proper divisors of n (numbers less than n
which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and
each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55
and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71
and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.
"""

def find_divisors(n):
    divisors = []
    for i in range(1,n//2+1):
        if n % i == 0:
            divisors.append(i)
    return divisors
def main():
    amicables = []
    for i in range(1,10000):
        #print("i: ",i)
        c_sum = sum(find_divisors(i))
        #print("c_sum: ",c_sum)
        if (sum(find_divisors(c_sum))== i) and (c_sum != i):
            amicables.append(i)

    print(sum(amicables))



        
