"""
Using names.txt (right click and 'Save Link/Target As...'), a 46K text file
containing over five-thousand first names, begin by sorting it into
alphabetical order. Then working out the alphabetical value for each name,
multiply this value by its alphabetical position in the list to obtain a name
score.

For example, when the list is sorted into alphabetical order, COLIN, which is
worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN
would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?
"""
from time import *
start = clock()
names = sorted(open("names.txt").read().lower().replace('"','').split(','))

##total = 0
##for i in range(len(names)):
##    current = 0
##    for char in names[i]:
##        current += (ord(char)-96)
##    total += (current*(i+1))
##    
total = sum([sum([ord(char)-96 for char in names[i]])*(i+1) for i in range(len(names))])
print(clock()-start)
