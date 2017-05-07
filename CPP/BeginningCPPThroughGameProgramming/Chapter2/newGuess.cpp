

#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

int main() {
    
    cout<<"Pick a number between 0 and 1,000\n";
    cin;
    int input;
    int max = 1000;
    int min = 0;
    int guess = 0;
    bool cont = true;
    while(cont) {
        srand(static_cast<unsigned int> (time(0))); // set rand
        // get it in the correct range (max - min), then shift up
        guess = rand()%(max-min+1) + min;
        cout<<"My guess is "<<guess;
        cout<<"\nIs that too high or too low?\n";
        cout<<"0 - too high!\n";
        cout<<"1 - too low!\n";
        cout<<"2 - you got it!\n";
        cin>>input;
        switch(input) {
            case 0:
                max = guess;
                break;
            case 1:
                min = guess;
                break;
            case 2:
                cont = false;
                break;
        }
               
    }
    
    return 0;
}