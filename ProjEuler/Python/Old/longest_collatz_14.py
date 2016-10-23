"""
The following iterative sequence is defined for the set of positive integers:

n -> n/2 (n is even)
n -> 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains
10 terms. Although it has not been proved yet (Collatz Problem), it is thought
that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.
"""

# which number, less than 1 million, produces the longest chain when:
# n%2 for even
# 3n+1 for odd
longest = 0
i=2
while i < 1000000:
    steps = 0
    curr = i
    while curr != 1:
        if curr%2==0:
            curr = curr/2
        else:
            curr = 3*curr + 1
        steps+=1
    if steps>longest:
        print(steps)
        longest=steps
        start=i
    i+=1
print(start)
