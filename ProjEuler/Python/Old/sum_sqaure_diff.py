"""
The sum of the squares of the first ten natural numbers is,

1^2 + 2^2 + ... + 10^2 = 385

The square of the sum of the first ten natural numbers is,

(1 + 2 + ... + 10)^2 = 552 = 3025

Hence the difference between the sum of the squares of the first ten natural
numbers and the square of the sum is 3025 - 385 = 2640.

Find the difference between the sum of the squares of the first one hundred
natural numbers and the square of the sum.
"""

def square_diff():
    numbers = [x for x in range(1,101)]
    sum_square = (sum(numbers))**2
    print(sum_square)
    square_sum = [x**2 for x in numbers]
    square_sum = sum(square_sum)
    print(square_sum)
    difference = sum_square - square_sum
    return difference

print(square_diff())
# Answer: 25164150        
