// v3
// 1+2*3
// addition, subtraction, multiplication and division with all numbers are single digit number

Console.Write("Ifodani kiriting: ");
string expression = Console.ReadLine();

int sum = 0;
int lastNumber = expression[0] - '0';

for(int index = 1; index < expression.Length; index += 2)
{
	switch(expression[index])
	{
		case '+':
			{
				sum += lastNumber;
				lastNumber = expression[index+1] - '0';
				break;
			}
		case '-':
			{
				sum += lastNumber;
				lastNumber = -(expression[index+1] - '0');
				break;
			}
		case '*':
			{
				lastNumber *= expression[index+1] - '0';
				break;
			}
		case '/':
			{
				lastNumber /= expression[index+1] - '0';
				break;
			}
	}
}

sum += lastNumber;

Console.WriteLine($"{expression}={sum}");