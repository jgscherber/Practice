#include <pthread.h>
#include <stdio.h>

void* thread(void* data) {
  while(1) {
    printf("Hello world from thread");
  }
  
}

int main(void) {
  pthread_t th;
  pthread_create(&th, NULL, thread, NULL);
  return 0;
}
