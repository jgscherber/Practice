
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main(int argc, char* argarr[]) {


  char argv[] = "this is the string";
  char* delim = " ";
  char* cmd = strtok(argv, delim);
  // argv[0] is name of file
  while(cmd != NULL) {
    printf("%s\n", cmd);
    cmd = strtok(NULL, delim);

  }

  /*
  if(system(cmd) == -1) {
    perror("System no execute");
  }
  */
  return 0;
}
