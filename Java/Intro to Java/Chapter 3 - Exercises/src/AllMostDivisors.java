
public class AllMostDivisors {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int top = 10_000;
		int[] divisors;
		int index;
		int max = 0;
		int m_index = -1;
		int[] m_divisors;
		int n_index = 0;
		m_divisors = new int[200];
		for (int test = 2; test<top;test++)
		{
				//System.out.print("Test: " + test);
				index = 0;
				
			for(int number = 2; number < Math.pow(test,0.5); number++)
			{
//				System.out.println("Div:" + (test/number));
				if (test%number == 0)
				{
					index++;
				}
			}
			if (index > m_index)
			{
				
				m_index = index;
			}
		
		}
		for (int test = 2; test<top;test++)
		{
				//System.out.print("Test: " + test);
				index = 0;
				
			for(int number = 2; number < Math.pow(test,0.5); number++)
			{
//				System.out.println("Div:" + (test/number));
				if (test%number == 0)
				{
					index++;
				}
			}
			if (index == m_index)
			{
				m_divisors[n_index] = test;
				n_index++;
			}
		
		}
		for (int i=0;i<n_index;i++)
			System.out.println(m_divisors[i]);

	}

}
