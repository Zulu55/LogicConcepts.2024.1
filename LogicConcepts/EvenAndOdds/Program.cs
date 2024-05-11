using System.ComponentModel.DataAnnotations;
using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** PARES E IMPARES EN ARREGLO ***");
    var n = ConsoleExtension.GetInt("Cuantas posiciones quieres en el arreglo? ");
    var numbers = new int[n];

    // Do process
    FillArray(numbers);
    var sum = GetSumEven(numbers);
    var prod = GetProdOdd(numbers);

    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    ShowArray(numbers);
    Console.WriteLine($"La sumatoria es  : {sum,30:N0}");
    Console.WriteLine($"La productoria es: {prod,30:N0}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double GetProdOdd(int[] numbers)
{
    double prod = 1;
    foreach (var number in numbers)
    {
        if (number % 2 != 0)
        {
            prod *= number;
        }
    }
    return prod;
}

int GetSumEven(int[] numbers)
{
    var sum = 0;
    foreach (var number in numbers)
    {
        if (number % 2 == 0)
        {
            sum += number;
        }
    }
    return sum;
}

void ShowArray(int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.Write($"{number,10:N0}");
    }
    Console.WriteLine();
}

void FillArray(int[] numbers)
{
    var random = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = random.Next(0, 100);
    }
}