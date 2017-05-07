
#include <iostream>
using namespace std;
int main() {
    
    float score1 = 0;
    float score2 = 0;
    float score3 = 0;
    
    cout << "Welcome to the Game Score Averager\n";
    cout << "Enter your first score: ";
    cin >> score1;
    
    cout << "Enter your second score: ";
    cin >> score2;
    
    cout << "Enter your third score score: ";
    cin >> score3;
    
    cout << "\nYour average is: " << (score1 + score2 + score3) / 3 << endl;

    return 0;
    
}