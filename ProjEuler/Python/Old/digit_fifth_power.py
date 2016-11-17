top = 10000000
powers = []
for i in range(2,top):
    numbs = list(str(i))
    sum1 = 0
    for k in numbs:
        sum1 += int(k)**5
    if sum1 == i:
        powers.append(i)


print(powers)
