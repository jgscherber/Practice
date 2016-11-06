"""
A permutation is an ordered arrangement of objects. For example, 3124 is one
possible permutation of the digits 1, 2, 3 and 4. If all of the permutations
are listed numerically or alphabetically, we call it lexicographic order. The
lexicographic permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5,
6, 7, 8 and 9?
"""
import math
digits = ['0','1','2','3','4','5','6','7','8','9']
# 362880 (9!) start with each number
# one millionth start with 2 (permutations 1088640 - 725760)

# 40320 (8!) of each 2-number has 12456789 as next number
# 6.8 to 1000000 -> towards the end of 26- , starts at 967680th perm.

# 5040 (7!) in the next digit -> 6.4 to millionth
# 267- -> 997920th perm
# 720 (6!) per next number -> 2.8 to millionth
# 2671- -> 999360th perm
# 120 (5!) -> 5.3 to millionith
# 26718- -> 999960th
# 24 (4!) -> 1.6
# 267180- -> 999984th
# 6 (3!) -> 2.6
# 2671804- -> 999996th
# 2 (2!) ->  2

# n!/k!(n-l)!
string = ''
posit = 0
for i in range(9,0,-1):
    poss = math.factorial(i)
    c_poss = 0
    #print("Before: ",posit)
    while posit+poss < 1000000:
        posit = posit + poss
        c_poss += poss
    #print("After: " ,posit)
    print("Index: ", posit//c_poss-1)
    string = string + str(digits.pop((posit//c_poss-1)))


print(string)
                                    
