alist = []
for i in range(10):
    alist.append(0)

while True:
    div = 1
    for i in range(10):
        if alist[i]%div == 0:
            if alist[i] == 0:
                alist[i] = 1
            else:
                alist[i] = 0
    div += 1
    if div > 10:
        break
print(alist)
            
