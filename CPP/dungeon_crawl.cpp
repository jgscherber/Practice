/*
Requires:
variables, data types, and numerical operators
basic input/output
logic (if statements, switch statements)
loops (for, while, do-while)
arrays

Make a program that outputs a simple grid based gameboard to the screen using either numbers or characters.
i.e.

. . . . . . . . . .
. G . . . . . . . .
. . . . . . T . . .
. . . . . . . . . .
. . . . T . . . . .
. . . . . . T . . .
. . . . . . . . . X


or

0 0 0 0 0 0 0 0 0 0
0 5 0 0 6 0 0 0 0 0
0 0 0 0 0 0 7 0 0 0
0 0 0 0 0 0 0 0 0 0
0 0 0 7 0 0 0 0 0 0
0 0 0 0 0 0 7 0 0 0
0 0 0 0 0 0 0 0 0 4


Allow the user (marked by G in the example) to move either up, down, left, or right each turn. If the 
player steps on a trap then they lose. If the make it to the treasure 'X' then they win.

1. Add enemies that move randomly in any direction once per turn. (enemies just like traps cause the 
player to lose if touched)

HINT: Don't let the player move off the gameboard! You program will crash if they move off the top or 
bottom of the board!(the same holds true for enemies)
*/
// represent each row as an array a giant array
// left right move by 1, up down move by 10
// actions triggered by having equal index values
// restrict valid inputs to -1< and <max
#include <iostream>
#include <string>
using namespace std;

int main()
{
    string row = ("G..........................T..............T..........T...............X");
    int player_loc = 0;
    int bad[3] = (28,43,55)
    for(int i=0;i<70;i++)
        {
            if((i%10==0) && (i!=0))
            cout<<endl;
            cout<<row[i];           
        }
        cout<<endl;
    while(player_loc != 69)
    {
        string move;
        // get the direction
        cout<<"Which direction do you want to move?"<<endl;
        cin>>move;
        cout<<endl;
        // changes player location according to move
        cout<<move<<endl;
        row[player_loc] = '.';
        if(move=="left")
            player_loc--;
        else if (move=="right")
            player_loc++;
        else if (move=="up")
            player_loc-=10;
        else if (move=="down")
            player_loc+=10;
        row[player_loc] = 'G';
        for(int i=0;i<70;i++)
        {
            if((i%10==0) && (i!=0))
            cout<<endl;
            cout<<row[i];           
        }
        cout<<endl;
        
    }

    
    
    
    return 0;
}

