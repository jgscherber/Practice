
#include <iostream>
using namespace std;

int main() {
    
    enum difficulty {Easy, Normal, Hard};
    
    difficulty choice;
    
    cout<<"Difficulty levels: \n";
    cout<<"1 - Easy\n";
    cout<<"2 - Normal\n";
    cout<<"3 - Hard\n";
    
    int in = 0;
    
    cout<<"Choice: ";
    cin>> in;
    
    // works
    choice = static_cast<difficulty> (in-1);
        
    switch(choice) {
        case Easy:
            cout<<"You picked easy.\n";
            break;
        case Normal:
            cout<<"You picked normal.\n";
            break;
        case Hard:
            cout<<"You picked hard.\n";
            break;        
    }
    
    return 0;
}