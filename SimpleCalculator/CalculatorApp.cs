using SimpleCalculator;
using System.Globalization;
using System.Linq.Expressions;

Console.WriteLine("Welcome to Simple Calculator!");
List<Calculation> history = new List<Calculation>();


while (true)
{
    Console.Clear();
    Console.WriteLine("=== Simple Calculator ===");

    double num1 = ReadNumber("Enter the first number: ");
    double num2 = ReadNumber("Enter the second number: ");
    string operation = ReadOperation();

    Calculation calculation = new Calculation();

    try
    {
        string result = calculation.PerformCalculation(num1, num2, operation);
        Console.WriteLine(result);
        history.Add(calculation);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Console.ReadKey();
        continue;
    }

    Console.WriteLine("Do you want to perform another calculation? (y/n): ");
    if (Console.ReadLine().ToLower() != "y")
    {
        Console.WriteLine("Show history? (y/n): ");
        if (Console.ReadLine() == "y")
        {
            Console.WriteLine("----- History -----");
            foreach (var h in history)
            {
                Console.WriteLine($"{h.Num1} {h.Operation} {h.Num2} = {h.Result} (at {h.CreatedAt})");
            }
            Console.ReadKey();
        }
        break;
    }
}

static double ReadNumber(string message)
{
    double number;
    Console.WriteLine(message);
    while (!double.TryParse(Console.ReadLine(), out number))
        Console.WriteLine("Invalid input. Try again");
    return number;
}

static string ReadOperation()
{
    while (true)
    {
        Console.WriteLine("Enter operation (+, -, *, /): ");
        string operation = Console.ReadLine();
        if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
            return operation;

        Console.WriteLine("Invalid operation.");
    }
}









