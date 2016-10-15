def sum_even_fib(top):
    f1 = 0
    f2 = 1
    total = 0
    f3=0
    while f3 < top:
        if (f3%2==0):
            total += f3
        f3 = f1 + f2
        f1 = f2
        f2 = f3
    return total
print(sum_even_fib(4000000))
