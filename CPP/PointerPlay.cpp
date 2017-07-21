// Example program
#include <iostream>
#include <string>

using namespace std;



int point(string * temp) { // take in a pointer to temp (it's address)
    *temp = "test"; // point to temp and write test
    return 0;
}

void change (int * input) { // difference between dereference type and dereference operator...
    int num = 4;
    int * test = &num;
    *input = *test * 7;
}

int main()
{
    string temp;
    point(&temp);
    cout<<temp;
    
    int temp2 = 3;
    change(&temp2);
    cout<<temp2;
    
    string both;
    string three = "three";
    both = *&three; // address dereferenced == data ... de-addressed? ... inspected?
    cout<<three;
}
