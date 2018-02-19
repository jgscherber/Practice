
#include <sys/stat.h>

#define FIFO_PERMS (S_IRUSR | S_IWUSR | S_IRGRP | S_IROTH)

int main() {
  mkfifo("test", FIFO_PERMS);
  

}
