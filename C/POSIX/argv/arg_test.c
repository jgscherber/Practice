
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main(int argc, char* argv[]) {

  printf("the number of arguments: %d\n", argc);
  for(int i = 0; i < argc; i++) {
    // need to increment the char** and then derefences to cycle through
    // the char*
    printf("%s\n", *(argv + i));
  }

  return 0;
}
