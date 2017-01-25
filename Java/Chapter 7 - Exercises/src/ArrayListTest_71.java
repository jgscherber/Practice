import java.util.ArrayList;

import javax.print.attribute.IntegerSyntax;

public class ArrayListTest_71 {
	
	public static ArrayList<Integer> generate(int num, int maximum) {
		ArrayList<Integer> result = new ArrayList<>();
		for (int i = 0; i < num; i++) {
			result.add((int)(Math.random()*maximum+1));			
		}//next i
		return result;		
	}//end generate
	
	
	public static void main(String[] args) {
		System.out.println(generate(5, 7));

	}

}
