/*
Walthrough of Problem 21
*/

#include <cmath>
#include <iostream>
using namespace std;

int divisor_sum(int n);


int main(){
    int sum = 0;
    
    int b;
    for(int a=2;a<10000;a++ )
    {
        b = divisor_sum(a);
        if(b>a)
        {
            if (divisor_sum(b) == a) {
                sum = sum + a + b;}
            
        }
               
    }
    
    cout<<sum<<endl;
    return 0;
}

// Divisors come in pairs that are all less than the square of the number
// Special cases of 1 and if the number is square (square only contributes one UNIQUE divisor)
// Also, odd numbers cannot have even divisors
int divisor_sum(int n)
{
    if(n==1) return 0;
    int r = floor(sqrt(n));
    int sum = 0;
    int f;
    int step;
    // check for square
    if (r*r == n){sum = 1 +r; r = r-1;}
    else
        sum = 1;
    if (n%2!=0){f= 3; step=2;}
    else{f = 2; step = 1;}
    while(f<=r)
    {
        if(n%f==0) sum = sum + f + (n/f);
        f = f + step;
    }
    
    return sum;
}