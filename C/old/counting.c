


#include <stdio.h>
#include <limits.h>

void countSort(int* arr, int length){
  // could use a bias-representation to sort positive and negative numbers
  int* output = malloc(sizeof(int) * (length + 2));
  // going to assume all input is positive for ease
  int max = INT_MIN;
  for(int i = 0; i < length; i++) {
    if(arr[i] > max) max = arr[i];
  }
  // counting array, should be cleared, need deful to be zero
  int* counts = calloc(sizeof(int), max);
  // count all the elements
  for(int i = 0; i < length; i++) {
    count[arr[i]]++;
  }
  

}
