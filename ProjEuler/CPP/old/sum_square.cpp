/* Sum of 1st n natural numbers: sum(n)=n(n+1)/2
Equation also exists for sum of squares:

Assume it's of form f(n)=an^3 +bn^2+cn + d -> 3rd derivative is contstant

n	0	1	2	3	4	5	6
n2	0	1	4	9	16	25	36
Sn	0	1	5	14	30	55	91
d1	    1	4	9	16	25	36
d2          3	5	7	9	11
d3              2	2	2	2

The first 4 n values yield 4 equations:
1.  d=0
2.  a + b + c = 1
3.  8a + 4b +2c + d =5
4. 27a + 9b + 3c + d =14

4 equations, 4 variables -> f(n) = n/6(2n+1)(n+1)
Double-check by induction

With 2 simplifications, problem is v. easy
*/

#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    int limit=100;
    float sum = limit*(limit+1)/2;
    float sum_sq = (2*limit+1)*(limit+1)*limit/6;
    int diff = pow(sum,2)-sum_sq;
    cout<<diff<<endl;
    
    
    
    
    
    return 0;
}