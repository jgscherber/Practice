#include <iostream>

int main() {
	int f1 = 0;
	int f2 = 1;
	int f3 = 0;
	int total = 0;
	while (f3 < 4000000)
	{
		if (f3 % 2 == 0)
			total += f3;
		f3 = f1 + f2;
		f1 = f2;
		f2 = f3;
	}
	std::cout << total << std::endl;

	return 0;
}