string expression = string.Empty;
decimal sum = 0;
int index = 0;
decimal lastNumber = 0;
decimal currentNumber = 0;
char operation = '+';

while(true)
{
  Console.WriteLine("\n╔══════════════════════════════╗");
  Console.WriteLine("║          CalString           ║");
  Console.WriteLine("╠══════════════════════════════╣");
  Console.WriteLine("║ 1. V1 │ Faqat qo'shish       ║");
  Console.WriteLine("║ 2. V2 │ +  va  -             ║");
  Console.WriteLine("║ 3. V3 │ + - * /              ║");
  Console.WriteLine("║ 4. V4 │ Ko'p xonali (2 son)  ║");
  Console.WriteLine("║ 5. V5 │ Ko'p xonali          ║");
	Console.WriteLine("║ 6. V6 │ Ko'p xonali (qavs)   ║");
  Console.WriteLine("║ 0.    │ Chiqish              ║");
  Console.WriteLine("╚══════════════════════════════╝");

  Console.Write("Tanlang: ");
  string? option = Console.ReadLine();

	if(option == "1" || option == "2" || option == "3" || option == "4" || option == "5" || option == "6")
	{
		Console.Write("Ifodani kiriting: ");
		expression = Console.ReadLine()!;
	}

  switch(option)
  {
    case "0":
		case "":
      {
        return;
      }
    case "1":
      {
				while(index < expression.Length)
				{
					sum += expression[index] - '0';
					index += 2;
				}

        break;
      }
    case "2":
      {
				while(index < expression.Length)
				{
					if(index == 0)
					{
						sum += expression[index] - '0';
					}
					else if (expression[index-1] == '+'){
						sum += expression[index] - '0';
					}
					else if (expression[index-1] == '-')
					{
						sum -= expression[index] - '0';
					}
					
					index += 2;
				}

        break;
      }
    case "3":
      {
				lastNumber = expression[0] - '0';

				for(index = 1; index < expression.Length; index += 2)
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

        break;
      }
    case "4":
      {
				while (index < expression.Length)
				{
					char operationStr = expression[index];
					switch (operationStr)
					{
						case '+':
							{
								decimal firstNumber = Convert.ToDecimal(expression.Substring(0, index));
								decimal secondNumber = Convert.ToDecimal(expression.Substring(index+1));
								sum = firstNumber + secondNumber;
								break;
							}
						case '-':
							{
								decimal firstNumber = Convert.ToDecimal(expression.Substring(0, index));
								decimal secondNumber = Convert.ToDecimal(expression.Substring(index+1));
								sum = firstNumber - secondNumber;
								break;
							}
						case '/':
							{
								decimal firstNumber = Convert.ToDecimal(expression.Substring(0, index));
								decimal secondNumber = Convert.ToDecimal(expression.Substring(index+1));
								sum = firstNumber / secondNumber;
								break;
							}
						case '*':
							{
								decimal firstNumber = Convert.ToDecimal(expression.Substring(0, index));
								decimal secondNumber = Convert.ToDecimal(expression.Substring(index+1));
								sum = firstNumber * secondNumber;
								break;
							}
					}
					index++;
				}
        break;
      }
    case "5":
      {

				for(index = 0; index < expression.Length; index++)
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

        break;
      }
		case "6":
			{
				string fullExpression = expression;
				int openIndex = -1;
				int closeIndex = -1;
				bool isWithParentheses = true;
				string innerExpression = string.Empty;

				while(isWithParentheses)
				{
					openIndex = -1;
					closeIndex = -1;

					for(int i = 0; i < fullExpression.Length; i++)
					{
						if(fullExpression[i] == '(')
						{
							openIndex = i;
						}
					}

					if (openIndex != -1)
					{
						for(int j = openIndex; j < fullExpression.Length; j++)
						{
							if(fullExpression[j] == ')')
							{
								closeIndex = j;

								sum = 0;
								lastNumber = 0;
								currentNumber = 0;
								operation = '+';
								innerExpression = fullExpression.Substring(openIndex + 1, closeIndex - openIndex - 1);

								for(index = 0; index < innerExpression.Length; index++)
								{
									switch(innerExpression[index])
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

												operation = innerExpression[index];
												currentNumber = 0;
												break;
											}
										default:
											{
												currentNumber = currentNumber * 10 + (innerExpression[index] - '0');
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

								fullExpression = $"{fullExpression.Substring(0, openIndex)}{sum}{fullExpression.Substring(closeIndex+1)}";

								break;
							}

						}
					} 
					else
					{
						sum = 0;
						lastNumber = 0;
						currentNumber = 0;
						operation = '+';
						isWithParentheses = false;

						for(index = 0; index < fullExpression.Length; index++)
						{
							switch(fullExpression[index])
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

										operation = fullExpression[index];
										currentNumber = 0;
										break;
									}
								default:
									{
										currentNumber = currentNumber * 10 + (fullExpression[index] - '0');
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
					}
				}
				break;
			}
  }

	Console.WriteLine($"{expression}={sum}\n");

	expression = string.Empty;
	sum = 0;
	index = 0;
	lastNumber = 0;
	currentNumber = 0;
	operation = '+';

	Console.Write("Davom etasizmi? ");
	if (!(Console.ReadLine()?.ToLower() == "ha")) return;
}