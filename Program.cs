// v5
// 12*45/2+23
// addition, subtraction, multiplication and division with multi numbers are multi digit number

Console.Write("Ifodani kiriting: ");
string expression = Console.ReadLine();

int sum = 0;
int lastNumber = 0;
int currentNumber = 0;
char operation = '+';

for(int index = 0; index < expression.Length; index++)
{
	switch(expression[index])
	{
		case '+':
		case '-':
		case '*':
		case '/':
			{
				switch (operation)
				{
					case '+':
						{
							sum += lastNumber;
							lastNumber = currentNumber;
							break;
						}
					case '-':
						{
							sum += lastNumber;
							lastNumber = -currentNumber;
							break;
						}
					case '*':
						{
							lastNumber *= currentNumber;
							break;
						}
					case '/':
						{
							lastNumber /= currentNumber;
							break;
						}
				}

				operation = expression[index];
				currentNumber = 0;
				break;
			}
		default:
			{
				currentNumber = currentNumber * 10 + (expression[index] - '0');
				break;
			}
	}
}

switch (operation)
{
	case '+':
		{
			sum += lastNumber;
			lastNumber = currentNumber;
			break;
		}
	case '-':
		{
			sum += lastNumber;
			lastNumber = -currentNumber;
			break;
		}
	case '*':
		{
			lastNumber *= currentNumber;
			break;
		}
	case '/':
		{
			lastNumber /= currentNumber;
			break;
		}
}

sum += lastNumber;

Console.WriteLine($"{expression}={sum}");