"""
If the numbers 1 to 5 are written out in words: one, two, three, four, five,
then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in
words, how many letters would be used?


NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and
forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20
letters. The use of "and" when writing out numbers is in compliance with
British usage.

HYPHEN BETWEEN TENS-ONE
AND BETWEEN HUNDREDS AND TENS (COUNT AND LETTERS)
"""

# dict with key value pairs
# tuple with connectors (hyphen, and, hundred, thousand)
def numbertword(n):
    uniques = {
        1:'one', 2:'two', 3:'three', 4:'four', 5:'five',
        6:'six', 7:'seven', 8:'eight', 9:'nine', 10:'ten',
        11:'eleven', 12:'twelve', 13:'thirteen', 14:'fourteen', 15:'fifteen',
        16:'sixteen', 17:'seventeen', 18:'eighteen', 19:'nineteen', 20:'twenty',
        30:'thirty', 40:'forty', 50:'fifty', 60:'sixty', 70:'seventy',
        80:'eighty', 90:'ninety', 0:'' }
    construct = ('hundred', 'thousand', '-','and')
    num_str = ''
    if n >= 1000:
        num_str += uniques[n//1000] + ' ' + construct[1]
        n %= 1000
        if n!=0:
            num_str += ' '
    if n >= 100:
        num_str += uniques[n//100] + ' ' + construct[0]
        n %= 100
        if n!= 0:
            num_str += ' ' + construct[3] + ' '
    # error was here: 15 being evaluated as 10-five
    if n >= 20:
        num_str += uniques[(n//10)*10]
        n%=10
        if n!=0:
            num_str+=construct[2]
    if n < 20:
        num_str+=uniques[n]
    return num_str

total = 0
for i in range(1,1001):
    word = numbertword(i)
    for char in word:
        if char not in ["-", " "]:
            total+=1
print(total) # originally off by 40 letters (21084)
# 21124


    
        
    
