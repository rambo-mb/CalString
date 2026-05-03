// v2
// 1+2-3
// addition and subtraction with all numbers are single digit number

Console.Write("Ifodani kiriting: ");
string expression = Console.ReadLine();

int sum = 0;
int index = 0;

while(index < expression.Length)
{
	if(index == 0)
	{
		sum += Convert.ToInt32(expression[index].ToString());
	}
	else if (expression[index-1] == '+'){
		sum += Convert.ToInt32(expression[index].ToString());
	}
	else if (expression[index-1] == '-')
	{
		sum -= Convert.ToInt32(expression[index].ToString());
	}
	
	index += 2;
}

Console.WriteLine($"{expression}={sum}");