# Bank account example from:
# http://anandology.com/python-practice-book/object_oriented_programming.html

"""
# returns a dictionary? function? Assignment has a 'function' type
def make_account():
    return{'balance' : 0}

# takes in a dictionary and value, adds value to dictionary value
# returns dictory key assignment
def deposit(account,amount):
    account['balance'] += amount
    return account['balance']

# does same as deposit, but subtracts
def withdraw(account, amount):
    account['balance'] -= amount
    return account['balance']
"""

"""
# need to class it like a function (e.g. a = BankAccount() )
class BankAccount:
    # sets initial conditions of class, property of balance equal to 0
    def __init__(self):
        self.balance = 0
    #takes in self (which contains the balance attribute) and an amount
    # subtracts the amount to the balance, then returns the self
    def withdraw(self, amount):
        self.balance -= amount
        return self.balance
    # same as above but adds amount
    def deposit(self, amount):
        self.balance += amount
        return self.balance
    
# ____Inheritence______
# takes another class as an argument
class MinimumBalanceAccount(BankAccount):
    # initialize the other class within this one using it's __init__ method
    # when init is execute (create a class instance), also need to pass
    # minimum_balance parameter to initialize minimum_balance property
    def __init__(self, minimum_balance):
        BankAccount.__init__(self)
        self.minimum_balance = minimum_balance
    # local scope will override global scope
    def withdraw(self, amount):
        if self.balance - amount < self.minimum_balance:
            print("Sorry, minimum balance must be maintained")
        else:
            # will "inherit" methods from classes passed into it
            # scope needs to be specificed if operator overloaded
            BankAccount.withdraw(self, amount)
"""

class A:
    def f(self):
        return self.g()
    def g(self):
        return 'A'

class B(A):
    def g(self):
        return 'B'

a = A()
b = B()

# returns A B for both
print(a.f(),b.f())  # should print A A -> b.f calls f within A, but self.g
                    # within B returns B (more local scope within B)
                    
print(a.g(), b.g()) # should print A B



            
