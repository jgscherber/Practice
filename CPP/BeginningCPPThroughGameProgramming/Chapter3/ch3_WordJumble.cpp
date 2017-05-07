

#include <iostream>
#include <string>
#include <cstdlib>
#include <ctime>

using namespace std;

int main() {
    enum fields {WORD, HINT, NUM_FIELDS};
    const int NUM_WORDS = 5;
    const string WORDS[NUM_WORDS][NUM_FIELDS] =
    {
        {"wall", "Do you feel you're banging your head against something?"},
        {"glasses", "These might help you see the answer."},
        {"labored", "Going slowly, is it?"},
        {"persistent", "Keep at it."},
        {"jumble", "It's what the game is all about."}
    };
    
    srand(static_cast<unsigned int>(time(0)));
    int choice = rand() % NUM_WORDS;
    string theWord = WORDS[choice][WORD];
    string theHint = WORDS[choice][HINT];
    
    // jumble a copy of the word
    string jumble = theWord;
    int length = jumble.size();
    for(int i = 0; i< length; i++) {
        int index1 = rand() % length;
        int index2 = rand() % length;
        char temp = jumble[index1];
        jumble[index1] = jumble[index2];
        jumble[index2] = temp;
    }
    
    cout<<jumble;
    
    string guess;
    cout << "\n\nEnter your guess: ";
    cin>> guess;
    
    int points = 0;
    
    while((guess != theWord) && (guess != "quit")) {
        if (guess == "hint") {
            points += 5;
            cout << theHint;
        } else {
            points += 1;
            cout << "Wrong";
        }
        
        cout << "\n\nYour guess: ";
        cin>>guess;
    }
    
    if(guess == theWord) {
        cout<< "You win\n";
        cout<<"Points: " << points << endl;
    }
    
    return 0;
}