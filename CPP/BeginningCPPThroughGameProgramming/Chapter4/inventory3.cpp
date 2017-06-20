
// Uses iterators

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
    
    // double colon notation = "scope resolution operator"
    // limiting the iterator to vector<string>?
    vector<string>::iterator myIterator;
    // iter of type const_iterator, can't use it to change the
    // value that the iterator is pointing at (constant)
    // explicit of intent and safer
    vector<string>::const_iterator iter;
    
    cout << "Your items\n";
    // vector.begin() returns a iterator starting at the first
    // element of the vector, vector.end() returns an iterator
    // one past the last element in the container (can't get a 
    // value from it)
    for(iter = inventory.begin(); iter != inventory.end(); iter++)
    {
        // dereference of iter as a pointer
        cout << *iter << endl; 
    }
    
    myIterator = inventory.begin();
    // dereferenced pointer == data
    *myIterator = "battle axe";
    
    cout << "Your items\n";
    for(iter = inventory.begin(); iter != inventory.end(); iter++)
    {
        // dereference of iter as a pointer
        cout << *iter << endl; 
    }
    
    cout << "\nThe item name '" << *myIterator << "' has ";
    // use paranthesis to force the dereference to run first
    cout << (*myIterator).size() << " letters in it.\n";
    
    cout << "\nThe item name '" << *myIterator << "' has ";
    // send the myIterator object to the size() method?
    cout << myIterator->size() << " letters in it.\n";
    
    return 0;
    
} // end main()