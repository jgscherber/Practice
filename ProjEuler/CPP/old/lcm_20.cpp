// n = 20 easy to brute force
#include <vector>
#include <iostream>
#include <cmath>
using namespace std;

void prime_vec(int max, vector<int> *primes);
int main()
{
    int k = 20;
    vector<int> primes;
    prime_vec(k*2, &primes);
    vector<float> a;
    int N = 1;
    int i = 0;
    bool check = true;
    float limit = sqrt(k);
    while(primes[i] <= k)
    {
        a.push_back(1);
        if(check)
        {
            if(primes[i]<=limit)
                a[i] = floor(log(k)/log(primes[i]));
            else
                check = false;
        }
        N = N * pow(primes[i],a[i]);
        i++;
    }
    cout<<N<<endl;  
    
    
    return 0;
}

void prime_vec(int max, vector<int> *primes)
{
    vector<int> temp = *primes;
    temp.push_back(2);
    for(int i = 3; i<=max; i++)
    {
        bool prime = true;
        for(int j=0;j<temp.size() && temp[j]*temp[j] <= i; j++)
        {
            if (i % temp[j] == 0)
            {
                prime=false;
                break;
            }
        }
        if(prime)
            temp.push_back(i);
    }       
    *primes = temp;
    
    
}