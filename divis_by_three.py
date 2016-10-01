def get_input():
    number = int(input("Enter a whole number: "))
    return number
def divisible_by_three(number):
    while number > 9:
        number = list(str(number))
        for i in range(len(number)):
            number[i] = int(number[i])
        number = sum(number)

    if number in [3,6,9]:
        print("Divisible by 3")
    else:
        print("Not divisible by 3")

number = get_input()
divisible_by_three(number)
