"""
A palindromic number reads the same both ways. The largest palindrome made
from the product of two 2-digit numbers is 9009 = 91 x 99.

Find the largest palindrome made from the product of two 3-digit numbers.
"""

# range 100 - 999
def largest_prods():
    largest = 0
    new_largest = 0
    for p1 in range(100, 1000):
        for p2 in range(100, 1000):
            product = str(p1 * p2)
            j = len(product)-1
            for i in range(j+1):
                if product[i] != product[j]:
                    break
                if i == (len(product)//2):
                    new_largest = product
                j-=1
            
            # originally had a string comparing to an into. Found the largest ord
            # 99999
            if int(new_largest) > largest:
                largest = int(new_largest)
                lp1 = p1
                lp2 = p2
    return largest, lp1, lp2
    
# largest: 906609 = 913 x 993
print(largest_prods())
