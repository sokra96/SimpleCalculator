using System.Globalization;

Console.WriteLine("Welcome to Simple Calculator!");

Console.WriteLine("Εnter the first number: ");
int num1;
while (!int.TryParse(Console.ReadLine(), out num1))
{
    Console.WriteLine("Invalid input! Please enter a number");
}

Console.WriteLine("Enter the second number: ");
int num2;
while (!int.TryParse(Console.ReadLine(), out num2))
{
    Console.WriteLine("Invalid input! Please enter a number");
}


int result;
while (true)
{
    Console.WriteLine("Enter operation (+ or -): ");
    String operation = Console.ReadLine();
    if (operation == "+")
    {
        result = num1 + num2;
        break;
    }
    else if (operation == "-")
    {
        result = num1 - num2;
        break;
    }
    else
    {
        Console.WriteLine("Please enter a valid operation (+ or -)");
    }
   
}
Console.WriteLine("Result is : " + result);
Console.ReadKey();



