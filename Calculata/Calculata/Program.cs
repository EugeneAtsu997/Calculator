using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            List<double> numbers = new List<double>();
            List<char> operators = new List<char>();

            bool expectNumber = true; // Flag to expect a number input

            // Prompt the user to enter a number followed by an operator, and repeat until "=" is entered
            while (true)
            {
                if (expectNumber)
                {
                    Console.Write("Enter a number: ");
                    string numberInput = Console.ReadLine();

                    if (numberInput == "=")
                    {
                        Console.WriteLine("Invalid input! Please enter a number followed by an operator.");
                        continue;
                    }

                    if (!double.TryParse(numberInput, out double number))
                    {
                        Console.WriteLine("Invalid input! Please enter a valid number.");
                        continue;
                    }

                    numbers.Add(number);
                    expectNumber = false;
                }
                else
                {
                    Console.Write("Enter an operator (+, -, *, /) (or press = to calculate): ");
                    string operatorInput = Console.ReadLine();

                    if (operatorInput == "=")
                    {
                        if (numbers.Count < 2)
                        {
                            Console.WriteLine("Please enter at least two numbers.");
                            continue;
                        }
                        break;
                    }

                    if (operatorInput.Length != 1 || (operatorInput[0] != '+' && operatorInput[0] != '-' && operatorInput[0] != '*' && operatorInput[0] != '/'))
                    {
                        Console.WriteLine("Invalid input! Please enter a valid operator.");
                        continue;
                    }

                    operators.Add(operatorInput[0]);
                    expectNumber = true;
                }
            }

            double result = CalculateResult(operators, numbers);
            Console.WriteLine($"Result: {result}");
        }
        catch
        {
            Console.WriteLine("Cannot perform calculation based on your input");
        }
    }

    // Calculation of results
    static double CalculateResult(List<char> operators, List<double> numbers)
    {
        double result = numbers[0];

        for (int i = 0; i < operators.Count; i++)
        {
            char arithmeticOperator = operators[i];

            if (i + 1 >= numbers.Count)
            {
                Console.WriteLine("Invalid input! Please enter a number after an operator.");
                return double.NaN;
            }

            double nextNumber = numbers[i + 1];

            switch (arithmeticOperator)
            {
                case '+':
                    result += nextNumber;
                    break;
                case '-':
                    result -= nextNumber;
                    break;
                case '*':
                    result *= nextNumber;
                    break;
                case '/':
                    if (nextNumber != 0)
                    {
                        result /= nextNumber;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        return double.NaN;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator! Please try again.");
                    return double.NaN;
            }
        }

        return result;
    }
}
