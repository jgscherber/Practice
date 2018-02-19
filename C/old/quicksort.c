// C implementation of quicksort
// from http://www.geeksforgeeks.org/quick-sort/

#include<stdio.h>

void swap(int* a, int* b) {
  int t = *a; // dereference
  *a = *b; // a points to where b pointed
  *b = t; // change where b points
}

/* takes a pivot, moves all smaller elements to the front and then
 * moves the pivot. Seperating the array into two sub-arrays: one
 * with all the elements smaller than the pivot and one with all
 * the elements larger than the pivot. int type return because needs
 * to return pivot position for recursive calls */
int partition (int arr[], int low, int high) {
  int pivot = arr[high]; // the pseudo-end of the array
  /* tracks location to put the low element, always incremenets by one
   * prior to inserting (that's why low-1) */
  int i = (low-1);

  // loop and swap
  for(int j = low; j<=high-1; j++) {
    /* if element is already on the correct side,
     *  it swaps it with itself */
    if(arr[j] <= pivot) {
      i++;
      //need to pass addresses (expects int*)
      swap(&arr[i], &arr[j]);
    }
  }
  // move pivot into position
  swap(&arr[i+1], &arr[high]);
  // needs to return pivot position for recursive calls
  return (i+1);
  
}//end partition

void quickSort(int arr[], int low, int high) {
  /* terminating case is when low > high due to the (partion + 1)
   * and (partition - 1) expressions in the recursive calls */
  if(low < high) {
    // real work is done in partition function
    int pi = partition(arr, low, high);

    // element at arr[pi] is in correct place and can excluded from
    // the recursive calls of quickSort
    quickSort(arr, low, pi-1);
    quickSort(arr, pi+1, high);
  }
}
