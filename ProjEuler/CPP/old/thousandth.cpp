/*
____Sieve of Eratosthenes____
o 1 is not prime
o All primes except 2 are odd
o All primes greater than 3 can be written as 6k+/-1
o Any number can only have one primefactor greater than sqrt(n) (itself)
*/


#include <iostream>
#include <cmath>
using namespace std;

bool isprime(int n);

int main()
{
    int limit = 10001;
    int count=1;
    int candidate = 1;
    while(count<limit)
    {
        candidate+=2;
        if(isprime(candidate))
            count+=1;
    }
    cout<<candidate<<endl;  
    
    
    return 0;
}

// function to check if a number, n, is prime
bool isprime(int n)
{
    if(n==1)
        return false;
    else if(n<4)
        return true;
    else if(n%2==0)
        return false;
    else if(n<9)
        return true;
    else if(n%3==0)
        return false;
    else{
        int r = floor(sqrt(n));
        int f = 5;
        while(f<=r)
        {
            if(n%f==0)
                return false;
            if(n%(f+2)==0)
                return false;
            f+=6;
        }
    return true;        
    }    
}