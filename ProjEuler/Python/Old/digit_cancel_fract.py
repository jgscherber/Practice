"""
The fraction 49/98 is a curious fraction, as an inexperienced mathematician
in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which
is correct, is obtained by cancelling the 9s.

We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

There are exactly four non-trivial examples of this type of fraction, less
than one in value, and containing two digits in the numerator and denominator.

If the product of these four fractions is given in its lowest common terms,
find the value of the denominator.
"""

# Fractions less than one
# Numerator and denominator are two digits
# Four examples

def digit_canceling(n,d):
    n_l = list(str(n))
    d_l = list(str(d))
    poss = False
    loc_n = 0
    loc_d = 0

    for i in range(len(n_l)):
        for j in range(len(d_l)):
            if (n_l[i] == d_l[j]) and (n_l[i] != '0'):
                poss = True
                loc_n = i
                loc_d = j
    if poss:
        del n_l[loc_n]
        del d_l[loc_d]
        n_l = ''.join(n_l)
        d_l = ''.join(d_l)
        if int(d_l) == 0:
            return False
        if n/d == int(n_l)/int(d_l):
            return True
    return False
    
        
            
ans = []
for d in range(10,99):
    for n in range(10,98):
        if n >= d:
            pass
        else:
            if digit_canceling(n,d):
                ans.append(str(n)+"/"+str(d))
