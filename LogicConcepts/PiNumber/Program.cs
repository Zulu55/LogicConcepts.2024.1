using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** CÁLCULO DEL NÚMERO pi ***");
    var n = ConsoleExtension.GetInt("Cuantos términos de presición quieres: ");

    // Do process
    var pi = CalcultePi(n);

    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine($"El valor de 'pi' con: {n} términos de presición es: {pi}");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalcultePi(int n)
{
    double sum = 0;
    double den = 1;
    int sig = 1;
    for (int i = 0; i < n; i++)
    {
        double ter = 1 / den * sig;
        sum += ter;
        den += 2;
        sig *= -1;
    }
    return sum * 4;
}