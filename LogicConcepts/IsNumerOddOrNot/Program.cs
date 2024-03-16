using Shared;

var number = 0;
do
{
    number = ConsoleExtension.GetInt("Ingrese número entero ó 0 para salir: ");
    if (number % 2 == 0)
    {
        Console.WriteLine($"El número {number}, es par.");
    }
    else
    {
        Console.WriteLine($"El número {number}, es impar.");
    }
} while (number != 0);
Console.WriteLine("Game Over.");