


// Quick Sort
// Worst Case: n^2
// Average Case: n log n


public class quick{
  
  public static void main(String... args) {
    int[] unsort = new int[] {3,7,5,4,1,9,12};
    
    quicksort(unsort);
    System.out.print("[ ");
    for(int a : unsort) {
     System.out.printf("%d, ", a); 
    }
    System.out.print("]");
    
  }
  
  public static void quicksort(int[] temp){
    int low = 0, high = temp.length-1;
    quicksort(temp,low,high);
  }
  
  private static void quicksort(int[] array, int low, int high) {
    if(low < high) {
      // partition code does the sorting
      int p  = partition(array,low,high); 
      
      // recursively call on each side of correction position
      quicksort(array, low, p-1);
      quicksort(array, p+1, high);
    }
    
  }
  
  private static int partition(int[] array, int low, int high) {
    int pivot = array[high];
    int i = low - 1;
    for(int j = low; j < high; j++) {
      // moving less than to left
      if(array[j] < pivot) {
        i++;
        // swap a(i) and a(j)
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
      }      
    }
    // puts the pivot in the correct place
    if(array[high] < array[i+1]) {
      int temp = array[high];
      array[high] = array[i+1];
      array[i+1] = temp;
    }
    return i+1; 
  }
  
  
}
