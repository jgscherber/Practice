
public class Transpose2DArray_72 {
	
	public static int[][] transpose(int[][] input) {
		int rows = input.length;
		int cols = input[0].length;
		
		int[][] t = new int[cols][rows];
		for (int i = 0; i < rows; i++) {
			for(int j = 0; j<cols;j++) {
				t[j][i] = input[i][j];	
				
			}// next j
		}//next i
		
		return t;
		
		
	} // end transpose
	
	public static void main(String[] args) {
		int[][] test = {{1,2,3},{4,5, 6},{7,8,9}};
		int[][] exp = transpose(test);
		//System.out.println(exp[0].length);
		for (int i =0;i<test.length;i++) {
			for(int j=0;j<test.length;j++){
				//System.out.println(Integer.toString(i) + Integer.toString(j));
				System.out.print(test[i][j]);
			}
			System.out.print("\n");
		}
		System.out.println();
		for (int i =0;i<exp.length;i++) {
			for(int j=0;j<exp.length;j++){
				//System.out.println(Integer.toString(i) + Integer.toString(j));
				System.out.print(exp[i][j]);
			}
			System.out.print("\n");
		}

	}

}
