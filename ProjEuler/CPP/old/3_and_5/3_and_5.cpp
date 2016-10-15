#include <iostream>
#include <iterator>
#include <numeric>
using namespace std;

int main(){
	int counter=0;
	int total=0;
	for (int i = 3; i < 1000; ++i) {
		if ((i % 3 == 0) || (i % 5 == 0))
		{
			counter++;
		}
		
	}
	int* multiples = new int[counter];
	counter = 0;
	for (int j = 3; j < 1000; ++j) {
		if ((j % 3 == 0) || (j % 5 == 0))
		{
			multiples[counter] = j;
			counter++;
		}
		
	}
	for (int k = 0; k < counter; ++k)
		total += multiples[k];
	
	cout << total << endl;

	return 0;
}