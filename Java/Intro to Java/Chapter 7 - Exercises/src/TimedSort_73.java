import java.util.Arrays;


public class TimedSort_73 {

	public static int[] selectionSort(int[] needsSort) {
		//implement selection sort (finds largest, moves to end, finds next largest, etc.)
		for (int lastPlace = needsSort.length -1; lastPlace > 0; lastPlace--) {
			
			int maxloc = 0;
			for (int j=1; j<=lastPlace; j++){
				if(needsSort[j] > needsSort[maxloc]){
					maxloc = j;
				}				
			}//next j
			int temp = needsSort[maxloc];
			needsSort[maxloc] = needsSort[lastPlace];
			needsSort[lastPlace] = temp;
			
			
		}//next lastPlace	
		return needsSort;
	}//end selectionSort
		
	static void insertionSort(int[] A) {
		
		int itemsSorted;
		
		for (itemsSorted = 1; itemsSorted < A.length; itemsSorted++) {
			int temp = A[itemsSorted];
			int loc = itemsSorted - 1;
			while(loc >= 0 && A[loc] > temp) {
				A[loc + 1] = A[loc];
				loc = loc - 1;
			}
			A[loc + 1] = temp;
			
		}		
	}//end insert
	
	
	
	
	public static void main(String[] args) {
		int[] unsorted = new int[10000];
		for (int i = 0; i < 10000; i++) {
			unsorted[i] = (int)(Math.random() *21);			
		}
		int[] unsorted2 = Arrays.copyOf(unsorted, unsorted.length);
		int[] unsorted3 = Arrays.copyOf(unsorted, unsorted.length);
	// time selection sort vs. built in sort
	// System.currentTimeMillis()
		
		double start;
		double end;
		double diff;
		start = System.currentTimeMillis();
		selectionSort(unsorted);
		end = System.currentTimeMillis();
		System.out.println("Selection sort took: " + (end - start)); // 62ms
		start = System.currentTimeMillis();
		Arrays.sort(unsorted2);
		end = System.currentTimeMillis();
		System.out.println("Built-in sort took: " + (end - start)); // 1ms (merge sort)
		start = System.currentTimeMillis();
		insertionSort(unsorted3);
		end = System.currentTimeMillis();
		System.out.println("Insertion sort took: " + (end - start)); // 43ms
		
	}//end main
}//end class
