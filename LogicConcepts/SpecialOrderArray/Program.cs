using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** ORDENACIÓN ESPECIAL DE UN ARREGLO ***");
    var n = ConsoleExtension.GetInt("Cuantas posiciones quieres en el arreglo? ");
    var numbers = new int[n];

    // Do process
    FillArray(numbers);

    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine("Arreglo sin ordenar =>");
    ShowArray(numbers);
    Console.WriteLine();

    var numbersEven = GetNumbersEven(numbers);
    var numbersOdd = GetNumbersOdd(numbers);
    OrderArray(numbersEven, true);
    OrderArray(numbersOdd);

    Console.WriteLine("Arreglo ordenado =>");
    ShowArray(numbersEven);
    ShowArray(numbersOdd);
    Console.WriteLine();

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

int[] GetNumbersOdd(int[] numbers)
{
    var contOdds = 0;
    foreach (var number in numbers)
    {
        if (!IsEven(number))
        {
            contOdds++;
        }
    }

    var numbersOdd = new int[contOdds];
    var i = 0;
    foreach (var number in numbers)
    {
        if (!IsEven(number))
        {
            numbersOdd[i] = number;
            i++;
        }
    }

    return numbersOdd;
}

int[] GetNumbersEven(int[] numbers)
{
    var contEvens = 0;
    foreach (var number in numbers)
    {
        if (IsEven(number))
        {
            contEvens++;
        }
    }

    var numbersEven = new int[contEvens];
    var i = 0;
    foreach (var number in numbers)
    {
        if (IsEven(number))
        {
            numbersEven[i] = number;
            i++;
        }
    }

    return numbersEven;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}

void OrderArray(int[] numbers, bool isDescending = false)
{
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        for (int j = i + 1; j < numbers.Length; j++)
        {
            if (isDescending)
            {
                if (numbers[i] < numbers[j])
                {
                    Change(ref numbers[i], ref numbers[j]);
                }
            }
            else
            {
                if (numbers[i] > numbers[j])
                {
                    Change(ref numbers[i], ref numbers[j]);
                }
            }
        }
    }
}

void Change(ref int number1, ref int number2)
{
    int aux = number1;
    number1 = number2;
    number2 = aux;
}

void ShowArray(int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.Write($"{number,10:N0}");
    }
}

void FillArray(int[] numbers)
{
    var random = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = random.Next(0, 100);
    }
}