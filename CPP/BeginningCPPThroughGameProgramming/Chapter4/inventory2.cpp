
#include <iostream>
#include <string>
#include <vector>

using namespace std;

int main() {
    // vector like ArrayList in Java
    vector<string> inventory;
    inventory.push_back("sword");
    inventory.push_back("armor");
    inventory.push_back("shield");
    
    cout << "You have " << inventory.size() << " items. \n";
    
    cout << "\nYour items: \n";
    for(unsigned int i = 0; i < inventory.size(); i++)
    {
        cout << inventory[i] << endl;
    }
    
    cout << "\nYou trade your sword for a battle axe.";
    inventory[0] = "battle axe";
    cout << "\nYour items: \n";
    for(unsigned int i = 0; i < inventory.size(); i++)
    {
        cout << inventory[i] << endl;
    }
    
    cout << "\nYour shield is destroyed in a fierce battle.";
    inventory.pop_back();
    cout << "\nYour items: \n";
    for(unsigned int i = 0; i < inventory.size(); i++)
    {
        cout << inventory[i] << endl;
    }
    cout << "You were robbed by a thief. \n";
    inventory.clear();
    if(inventory.empty())
    {
        cout<<"You have nothing left. \n";
    }
    else
    {
        cout<<"\nYou have at least one item.\n";
    }
    
    return 0;
    
} // end main()