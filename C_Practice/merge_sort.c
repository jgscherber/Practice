
// copy of merge sort to better understand
// from: http://www.geeksforgeeks.org/merge-sort/

#include<stdlib.h>
#include<stdio.h>

// first sub-array is arr[l..m] (left..mid)
// second sub-array is arr[m+1..r] (mid+1..right)
void merge(int arr[], int l, int m, int r) {

  int i, j, k; //loop variables
  
  int n1 = m - l + 1;
  int n2 = r - m;

  int* L = malloc(sizeof(int) * n1);
  int* R = malloc(sizeof(int) * n2);

  // copy data into temp arrays
  for(i = 0; i<n1; i++) {
    L[i] = arr[l+i];
  }
  for(j=0; j<n2; j++) {
    R[j] = arr[m + 1 + j];
  }
  i=j=0;
  k=l;// initial index of output (overrights array)

  /* if one of the input arrays is empty, will have 0 entries and the 
   * while loop will evaluate to false immediately (0!<0) and will skip 
   * down to transfering all the values from the list with values */
  while(i<n1 && j<n2) {
    if(L[i] <= R[j]) {
      arr[k] = L[i];
      i++;
    } else {
      arr[k] = R[j];
      j++;
    }
    k++;
  }
  // copy remaining elements
  while(i < n1) {
    arr[k] = L[i];
    i++;
    k++;
  }

  while(j < n2) {
    arr[k] = R[j];
    j++;
    k++;
  }
}

void mergeSort(int arr[], int l, int r) {
  if(l<r) {
    int m = l+(r-1)/2; // avoids overflow

    mergeSort(arr, l, m);
    mergeSort(arr, l, m, r);
  }
}
