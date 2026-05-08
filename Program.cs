string confirmation = string.Empty;
string expression = string.Empty;
decimal sum = 0;

do
{
	Console.Clear();
  Console.WriteLine("\n╔══════════════════════════════╗");
  Console.WriteLine("║          CalString           ║");
  Console.WriteLine("╠══════════════════════════════╣");

	Console.Write("Ifodani kiriting: ");
	expression = Console.ReadLine()!;

	expression = expression.Replace(" ", "");	

	string fullExpression = expression;

	while(hasParanthesis(fullExpression))
	{
		fullExpression = calculateParanthesis(fullExpression);
	}

	while (hasPower(fullExpression))
	{
		fullExpression = calculatePower(fullExpression);
	}

	sum = calculate(fullExpression);

	Console.WriteLine($"{expression}={sum}\n");

	expression = string.Empty;
	sum = 0;

	Console.Write("Davom etasizmi? ");
	confirmation = Console.ReadLine()!;
} while(confirmation.ToLower() == "ha");

static (int sum, int lastNumber) calculateOperations(char operation, int sum, int lastNumber, int currentNumber)
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

	return (sum, lastNumber);
}

static int calculate(string expression)
{
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
					(sum, lastNumber) = calculateOperations(operation, sum, lastNumber, currentNumber);

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

	(sum, lastNumber) = calculateOperations(operation, sum, lastNumber, currentNumber);

	sum += lastNumber;

	return sum;
}

static string calculateParanthesis(string expression)
{
	int openIndex = -1;
	int closeIndex = -1;
	string innerExpression = string.Empty;

	openIndex = expression.LastIndexOf('(');

	for(int j = openIndex; j < expression.Length; j++)
	{
		if(expression[j] == ')')
		{
			closeIndex = j;

			innerExpression = expression.Substring(openIndex + 1, closeIndex - openIndex - 1);

			while(hasPower(innerExpression))
			{
				innerExpression = calculatePower(innerExpression);
			}

			int sum = calculate(innerExpression);

			expression = $"{expression.Substring(0, openIndex)}{sum}{expression.Substring(closeIndex+1)}";

			break;
		}
	}
	return expression;
}

static bool hasParanthesis(string expression)
{
	int index = expression.LastIndexOf('(');

	return index != -1;
}

static string calculatePower(string expression)
{
	int currentNumber = 0;
	int lastNumber = 0;
	int sum;

	int index = expression.LastIndexOf('^');
							
	bool found = false;
	int indexCurrentNumber;
	int indexLastNumber;

	for(indexCurrentNumber = index + 1; indexCurrentNumber < expression.Length; indexCurrentNumber++)
	{
		switch(expression[indexCurrentNumber])
		{
			case '+':
			case '-':
			case '*':
			case '/':
				{
					currentNumber = Convert.ToInt32(expression.Substring(index + 1, indexCurrentNumber - index - 1));

					found = true;
					break;
				}
		}

		if (found) break;
	}

	if (!found) currentNumber = Convert.ToInt32(expression.Substring(index + 1));

	found = false;

	for(indexLastNumber = index - 1; indexLastNumber > -1; indexLastNumber--)
	{
		switch(expression[indexLastNumber])
		{
			case '+':
			case '-':
			case '*':
			case '/':
				{
					lastNumber = Convert.ToInt32(expression.Substring(indexLastNumber + 1, index - indexLastNumber - 1));

					found = true;
					break;
				}
		}

		if (found) break;
	}

	if (!found)	lastNumber = Convert.ToInt32(expression.Substring(0, index));

	sum = (int) Math.Pow(lastNumber, currentNumber);
	expression = $"{expression.Substring(0, indexLastNumber + 1)}{sum}{expression.Substring(indexCurrentNumber)}";

	return expression;
}

static bool hasPower(string expression)
{
	int index = expression.LastIndexOf('^');

	return index != -1;
}