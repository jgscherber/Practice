/* Write a program that presents the user w/ a choice of your 5 favorite beverages 
(Coke, Water, Sprite, ... , Whatever).
Then allow the user to choose a beverage by entering a number 1-5.
Output which beverage they chose.

If you program uses if statements instead of a switch statement, modify it to use a switch statement.
If instead your program uses a switch statement, modify it to use if/else-if statements.

Modify the program so that if the user enters a choice other than 1-5 then it will output 
"Error. choice was not valid, here is your money back." */
#include <iostream>
#include <string>
using namespace std;


int main()
{
    
    int choice;  
    string pops[] = {"Coke", "Water", "Sprite", "Cherry Coke", "Mountain Dew"};
    cout<<"Chose one of the pops:";
    for(int i=0; i<5; i++)
        cout<<" "<<pops[i];
    cout<<endl;
    cin>>choice;
    cout<<endl<<"You chose: "<<pops[choice-1]<<endl;
    
    
    
    
    
    
    return 0;
}