using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** TAYLOR ***");
    var n = ConsoleExtension.GetInt("Cuanto términos queres: ");
    var x = ConsoleExtension.GetDouble("Ingresa el valor de X : ");
    var taylor = Taylor(x, n);

    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Taylor con: {n} términinos => f({x}) = {taylor}");
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double Taylor(double x, int n)
{
    double sum = 0;
    for (var i = 0; i < n; i++)
    {
        double ter = Math.Pow(x, i) / MyMath.Factorial(i);
        sum += ter;
    }

    return sum;
}