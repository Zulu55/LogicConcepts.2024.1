using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** LOS N NÚMEROS PRIMOS ***");
    var n = ConsoleExtension.GetInt("Cuantos números primos queres: ");

    // Do process
    var primes = GetPrimes(n);


    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    foreach (var prime in primes)
    {
        Console.Write($"{prime,10:N0}");
    }
    Console.WriteLine();
    Console.WriteLine($"La sumatoria es: {primes.Sum(),10:N0}");
    Console.WriteLine($"El promedio    :    {primes.Average(),10:N2}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

List<int> GetPrimes(int n)
{
    var primes = new List<int>();
    var number = 2;
    while (primes.Count < n)
    {
        if (MyMath.IsPrime(number))
        {
            primes.Add(number);
        }
        number++;
    }
    return primes;
}