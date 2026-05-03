// v1
// 1+2+3
// only addition and all numbers are single digit number

Console.Write("Ifodani kiriting: ");
string expression = Console.ReadLine();

int sum = 0;
int index = 0;

while(index < expression.Length)
{
	sum += Convert.ToInt32(expression[index].ToString());
	index += 2;
}

Console.WriteLine($"{expression}={sum}");