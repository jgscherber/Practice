#include <iostream>
#include<string>
#include <sstream>
#include<cstdlib>


int main()
{
//char string = '123';
std::string s = '123';
int x;
std::istringstream(s) >> x;
//x = int (string);
x ++;
std::cout << x;
return 0;
}

