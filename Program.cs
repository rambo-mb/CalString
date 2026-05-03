// v4
// 12*45
// addition, subtraction, multiplication and division with 2 numbers are multi digit number

Console.Write("Ifodani kiritng: ");
string expression = Console.ReadLine();

int index = 0;

while (index < expression.Length)
{
	char operationStr = expression[index];
	switch (operationStr)
	{
		case '+':
			{
				decimal firstNumber = Convert.ToDecimal(expression.Substring(0, index));
				decimal secondNumber = Convert.ToDecimal(expression.Substring(index+1));
				Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
				break;
			}
		case '-':
			{
				decimal firstNumber = Convert.ToDecimal(expression.Substring(0, index));
				decimal secondNumber = Convert.ToDecimal(expression.Substring(index+1));
				Console.WriteLine($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
				break;
			}
		case '/':
			{
				decimal firstNumber = Convert.ToDecimal(expression.Substring(0, index));
				decimal secondNumber = Convert.ToDecimal(expression.Substring(index+1));
				Console.WriteLine($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
				break;
			}
		case '*':
			{
				decimal firstNumber = Convert.ToDecimal(expression.Substring(0, index));
				decimal secondNumber = Convert.ToDecimal(expression.Substring(index+1));
				Console.WriteLine($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
				break;
			}
	}
	index++;
}