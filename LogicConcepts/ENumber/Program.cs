using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** CÁLCULO DEL NÚMERO e ***");
    var n = ConsoleExtension.GetInt("Cuantos términos de presición quieres: ");

    // Do process
    var e = CalculteE(n);

    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine($"El valor de 'e' con: {n} términos de presición es: {e}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalculteE(int n)
{
    double sum = 0;
    for (var i = 0; i < n; i++)
    {
        sum += 1 / MyMath.Factorial(i);
    }
    return sum;
}