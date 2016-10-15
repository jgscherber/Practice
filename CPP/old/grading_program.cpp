
/* Write a program that allows the user to enter the grade scored in a programming class (0-100).
If the user scored a 100 then notify the user that they got a perfect score.

Modify the program so that if the user scored a 90-100 it informs the user that they scored an A

Modify the program so that it will notify the user of their letter grade
0-59 F 60-69 D 70-79 C 80-89 B 90-100 A */

#include <iostream>

int main(){
    int grade;
    std::cout<<"Enter the grade you received"<<std::endl;
    std::cin>>grade;
    // truncates grade to first digit for switch statement
    grade = grade/10;
    switch(grade){
        case 6: std::cout<<"You got an D"<<std::endl;        
        case 7: std::cout<<"You got an C"<<std::endl;
        case 8: std::cout<<"You got an B"<<std::endl;
        case 9: std::cout<<"You got an A"<<std::endl;
                break;  
        default: std::cout<<"You got an F"<<std::endl;
    }

 
    return 0;
}