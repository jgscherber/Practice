def generate_3_5_sums(top):
    multiples = []
    for i in range(3,top):
        if (i%3==0) or (i%5==0):
            multiples.append(i)
    return sum(multiples)

print(generate_3_5_sums(1000))

Recovery Key: 1043052-nyqKUmfktrUguE76M3myKu44hDqFbD0pu9qYB7fH
   Generated: Sun, 16 Oct 2016, 22:59.16
