using SimpleCalculator;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq.Expressions;

Console.WriteLine("Welcome to Simple Calculator!");
List<Calculation> history = new List<Calculation>();
int menuStartLine = 1;

while (true)
{
    Console.SetCursorPosition(1, menuStartLine);

    Console.WriteLine("=== Simple Calculator ===\n");
    try
    {
        Console.WriteLine("1.New calculation");
        Console.WriteLine("2.Show history");
        Console.WriteLine("3.Exit");
        Console.WriteLine("\nChoose an option: ");
        int option = ReadOption();

        if (option == 1)
        {
            Calculation calculation = new Calculation();
            double currentResult = ReadNumber("Enter a number: ");
            string expression = currentResult.ToString();
            while (true)
            {
                string operation = ReadOperation();
                if (operation == "=")
                {
                    Calculation finalCalculation = new Calculation();
                    finalCalculation.SetFinalResult(expression, currentResult);
                    history.Add(finalCalculation);
                    Console.WriteLine($"{expression} = {currentResult} ");
                    break;
                }
                double num2 = ReadNumber("Enter the next number: ");
                try
                {
                    currentResult = calculation.PerformCalculation(currentResult, num2, operation);
                    Console.WriteLine(currentResult);
                    expression += $" {operation} {num2}";
                } catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(currentResult);
                }
              
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();


        }
        else if (option == 2)
        {
            Console.WriteLine("----- History -----");
            foreach (var h in history)
            {
                Console.WriteLine($"{h.Expression} = {h.FinalResult} (at {h.CreatedAt})");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        else if (option == 3)
        {
            break;
        }
        Console.Clear();
        Console.SetCursorPosition(1, menuStartLine);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Console.ReadKey();
        Console.Clear();
        Console.SetCursorPosition(1, menuStartLine);
        continue;
    }

}

static int ReadOption()
{
    int number;
    while (!int.TryParse(Console.ReadLine(), out number)
        || (number != 1 && number != 2 && number != 3))
        Console.WriteLine("Invalid input. Choose 1, 2 or 3 from the menu!");
    return number;
}

static double ReadNumber(string message)
{
    double number;
    while (true)
    {
        Console.Write(message);
        if (double.TryParse(Console.ReadLine(), out number))
            return number;
        Console.WriteLine("Invalid input. Try again\n");
    }
}

static string ReadOperation()
{
    while (true)
    {
        Console.Write("Enter operation (+, -, *, /, =): ");
        string operation = Console.ReadLine();

        if (operation == "+" || operation == "-" || operation == "*" || operation == "/" || operation == "=")
            return operation;

        Console.WriteLine("Invalid operation. Please enter +, -, *, / or = .\n");
    }
}









