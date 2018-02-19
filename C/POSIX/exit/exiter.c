

#include <stdlib.h>
#include <stdio.h>

void test();
void crash();

int main(int argc, char* argv[]) {

  if(atexit(test) == -1) {
    perror("couldn't add to atexit");
        
  }

  crash();
  
  return 0;

}

void crash() {
  exit(0);

}

// runs on return from main and exit from functions
void test() {
  printf("inside test\n");

}
