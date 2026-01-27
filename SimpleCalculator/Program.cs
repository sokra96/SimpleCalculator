using System.Globalization;

Console.WriteLine("Welcome to Simple Calculator!");

while (true)
{
    Console.Clear();
    Console.WriteLine("Εnter the first number: ");
    int num1;
    while (!int.TryParse(Console.ReadLine(), out num1))
    {
        Console.WriteLine("Invalid input! Please enter a number: ");
    }



    Console.WriteLine("Enter the second number: ");
    int num2;
    while (!int.TryParse(Console.ReadLine(), out num2))
    {
        Console.WriteLine("Invalid input! Please enter a number: ");
    }

    string operation;
    while (true)
    {
        Console.WriteLine("Enter operation (+, -, * or / ): ");
        operation = Console.ReadLine();
        if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
        {
            break;
        }
        Console.WriteLine("Invalid operation! Please enter +, -, * or /.");
    }
    int result = 0;

    if (operation == "+")
    {
        result = num1 + num2;
    }
    else if (operation == "-")
    {
        result = num1 - num2;
    }
    else if (operation == "*")
    {
        result = num1 * num2;
    }
    else if (operation == "/")
    {
        while (num2 == 0)
        {
            Console.WriteLine("Division by 0 is not a valid operation, please enter a new number: ");
            while (!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Invalid input! Please enter a number: ");
            }

        }
        result = num1 / num2;
    }

    Console.WriteLine("Result is : " + result);
    Console.WriteLine("Do you want to perform another calculation? (y/n): ");
    string again = Console.ReadLine().ToLower();
    if (again != "y")
    {
        break;
    }

}





