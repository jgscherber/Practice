"""
You are given the following information, but you may prefer to do some
research for yourself.

o 1 Jan 1900 was a Monday.
o Thirty days has September,
  April, June and November.
  All the rest have thirty-one,
  Saving February alone,
  Which has twenty-eight, rain or shine.
  And on leap years, twenty-nine.
o A leap year occurs on any year evenly divisible by 4, but not on a century
  unless it is divisible by 400.
  
How many Sundays fell on the first of the month during the twentieth century
(1 Jan 1901 to 31 Dec 2000)?
"""

# Sunday = 6
# Monday = 0

# January = 0
# December = 11

# 1st = 0
# 28th = 27
# 29th = 28
# 30th = 29
# 31st = 30

# 1901 = 0
# 2000 = 99

sundays = 0
days = 0
year = 1901
while year <= 2000:
    if ((year % 4 == 0) and (year % 100 != 0)) or (year % 400 == 0):
        leap = True
    else:
        leap = False
    month = 1
    while month <= 12:
        #print(month)
        days_s = days-1
        if month in [9,4,6,11]:
            while days - days_s <= 30:
                
                if (days % 7 == 0) and (days - days_s == 1):
                    sundays +=1
                days += 1
        elif month == 2 and not leap:
            while days - days_s <= 28:
                #print(days-days_s)
                if (days % 7 == 0) and (days - days_s == 1):
                    sundays +=1
                days += 1
        elif month == 2 and leap:
            while days - days_s <= 29:
                if (days % 7 == 0) and (days - days_s == 1):
                    sundays +=1
                days += 1
        else:
            while days - days_s <= 31:
                if (days % 7 == 0) and (days - days_s == 1):
                    sundays +=1
                days += 1
        month += 1
    year += 1
print(sundays)
    
