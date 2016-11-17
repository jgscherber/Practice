#200 = 1x+2x+5x+10x+20x+60x+100x+200x

# Generating function: F(x) = 1/(1-x) * 1/(1-x^2) * 1/(1-x^5) * 1/(1-x^10) * ...


# 200 spots
# 8 dividors

# solution derived from: http://stackoverflow.com/questions/1106929/find-all-combinations-of-coins-when-given-some-dollar-value
# defined recurrently

coins = [1,2,5,10,20,50,100,200]
def countChange(money, coins):
    # if money = 0 the coins have been subtracted evenly
    if money == 0:
        return 1
    # if you run out of coins of go negative, it's not a valid combination
    if(len(coins) == 0) or (money < 0):
        return 0
    else:
        # first recursive call accounts for re-using coins, second for not
        return countChange(money-coins[0],coins)+ countChange(money, coins[1:])
        
print(countChange(200,coins))
