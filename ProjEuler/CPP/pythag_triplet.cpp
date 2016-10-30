// Combining the 2 equations: a^2 + b^2 = (s-a-b)^2
// If a<b<c, a <= (s-3)/3  and  b<(s-a)/2

#include <iostream>
#include <cmath>
using namespace std;

unsigned GCD(unsigned u, unsigned v);

int main()
{
    int s = 1000;
    int s2 = s/2;
    int mlimit = ceil(sqrt(s2))-1;
    
    for(int m=2;m<mlimit)
        if (s2%m==0)
        {
            int sm = s2/m;
            while(sm%2==0)
                sm = sm/2;
            if(m%2==1)
                int k = m+2;
            else
                k=m+1;
            while ((k<2*m) and (k<=sm))
                // HERE
                if((sm%k==0)and(GCD()
            
            
            
        }
    
    
    
    return 0;
}

unsigned GCD(unsigned u, unsigned v) 
{
    while ( v != 0) 
    {
        unsigned r = u % v;
        u = v;
        v = r;
    }
    return u;
}

/*
As the value of s is multiplied by k, the time is multiplied by k^2

int main()
{
	int s = 1000;
	for(int a=3;a<=(s-3)/3;a++)
	{
		for(int b=(a+1);b<(s-1-a)/2;b++)
		{
			int c = s-a-b;
			if (c*c == a*a + b*b)
				cout<<a*b*c<<endl;
		}
	}
	return 0;
}

*/

