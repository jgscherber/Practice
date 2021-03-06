import java.util.Scanner;


public class Calculator {

	public static void main(String[] args) {
		// simple calculator, exit on 0; operators: + , - , / , *
		// Has no input checking
		Scanner stdin = new Scanner(System.in);
		while(true)
		{
			
			float var1;
			System.out.print("Enter the first number (0 to exit): ");
			var1 = stdin.nextInt();
			if(var1==0)
			{
				stdin.close();
				return;				
			}
			String operator;
			System.out.print("Enter the operator (+,-,^,/): ");
			operator = stdin.next();
			float var2;
			System.out.print("Enter the second number: ");
			var2 = stdin.nextInt();
			//System.out.println(operator);
			float answer;
			
			if("+".equals(operator)) // == tests for memory equality (point to the same reference)
			{
				answer = var1 + var2;
			}
			else if("-".equals(operator))
			{
				answer = var1-var2;
			}
			else if("*".equals(operator))
			{
				answer = var1*var2;
			}
			else
			{
				answer = (float)var1/var2;
			}
			System.out.println(var1+operator+var2+"="+answer+"\n");
			
	}
		
	}

}
