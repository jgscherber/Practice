#include <iostream>
using namespace std;

void reverse(int n, int *reversed);
void isPalindrome(int n, bool *check);

int main()
{
    
    int largestPalindrome = 0;
    int a = 100;
    bool check=0;
    while(a<=999)
    {
        // assuming a<=b -> cuts checks in around half
        // faster to count down from 999 and exit once a palindrome has been found
        // fastest to rewrite as a line combination p = 1000000x + 10000y + 1000z + 100z + 10y + x
        // simplifying -> all palindromes of 6 digits have a common factor 11
        int b = a;
        
        while(b<=999)
        {
            int product = a*b;
            isPalindrome(product,&check);
            if(check && ((a*b) > largestPalindrome))
                largestPalindrome = a*b;
            
            b++;
        }
        a++;
    }
    cout<<largestPalindrome<<endl;
    
    
    return 0;
}

void isPalindrome(int n, bool *check)
{
    int b_n = n;
    reverse(n, &b_n);
    *check = (n == b_n);
}

void reverse(int n, int *reversed)
{
    int test = 0;
    while(n>0)
    {
               
        test = 10*test +(n%10);
        n/=10;
    }
    *reversed = test;
}

//Works!