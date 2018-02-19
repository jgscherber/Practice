#include <stdio.h>

int main(void) {
  pthread_t th;
  pthread_create(&th, NULL, thread, NULL);
  return 0;
}
