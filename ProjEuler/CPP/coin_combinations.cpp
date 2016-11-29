
#include <iostream>
using namespace std;
int ways(int target, int avc,int coins[8]);

int main()
{
    int coins[8] = {1,2,5,10,20,50,100,200};
    int amount = 200;
    cout<<ways(amount,7,coins)<<endl;
    
    return 0;
}

int ways(int target, int avc,int coins[8])
{
    
    if (avc <= 0) return 1;
    int res = 0;
    while(target>=0)
    {
        res = res + ways(target, avc-1, coins);
        target -= coins[avc];
    }
    return res;
}
