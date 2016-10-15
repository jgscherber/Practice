def generate_3_5_sums(top):
    multiples = []
    for i in range(3,top):
        if (i%3==0) or (i%5==0):
            multiples.append(i)
    return sum(multiples)

print(generate_3_5_sums(1000))
