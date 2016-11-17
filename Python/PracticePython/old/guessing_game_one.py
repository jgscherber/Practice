"""
Generate a random number between 1 and 9 (including 1 and 9). Ask the user to
guess the number, then tell them whether they guessed too low, too high, or
exactly right. (Hint: remember to use the user input lessons from the very first
exercise)

Extras:

Keep the game going until the user types “exit”
Keep track of how many guesses the user has taken, and when the game ends, print
this out.
"""

import random

def guess_get():
    number = random.randint(1,9)
    guess = 0
    while True:
        guess = input("What is your guess?")
        if guess.isdigit():
            guess = int(guess)
        else:
            break
        diff = number - guess
        if diff == 0:
            print("Congrats! That's correct!")
        elif diff < 0:
            print("Nope, too high")
        else:
            print("Nope, too low")
    
guess_get()
