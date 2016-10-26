#include <iostream>
using namespace std;

/*
int main()
{
 long n;
 int factor = 2;
 int lastFact = 1;
 cout<<"Enter the number:"<<endl;
 cin>>n;
 cout<<endl;
 while(n>1)
 {
     if(n%factor==0)
     {
         lastFact=factor;
         n=n/factor;
         while (n%factor==0)
             n=n/factor;
     }
  factor++;
 }
    cout<<lastFact<<endl;
    return 0;
}
*/

int main()
{
    long n;
    int lastFactor;
    cout<<"Enter the number:"<<endl;
    cin>>n;
    cout<<endl;
    //2 is the only even prime
    if(n%2==0)
    {
        n/=2;
        lastFactor=2;
        while(n%2==0)
            n/=2;
                
    }
    else
        lastFactor=1;
    // after 2 is checked, can start at 1st odd
    int factor=3;
    while(n>1)
    {
        if(n%factor==0)
        {
            n/=factor;
            lastFactor=factor;
            while(n%factor==0)
                n/=factor;
        }
    // then iterate only over odds
    factor+=2;
    }
    cout<<lastFactor<<endl;
    return 0;
}