

#include <unistd.h>
#include <stdio.h>


int main(int argc, char* argv[]) {

  pid_t mine = getpid();
  pid_t parent = getppid();

  printf("mine: %d parents: %d\n", mine, parent);

  if(!fork()) { // child returns 0
    printf("in the child, pid: %d, the childs parent is %d\n",
	   getpid(), getppid());
    exec(

  } else { // parent return pid > 0
    printf("in the parent %d\n", getpid());

  }
  return 0;
}
