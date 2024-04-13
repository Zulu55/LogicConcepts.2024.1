using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** FACTORIAL ***");
    var num = ConsoleExtension.GetInt("Ingrese el número al cual le deseas calcular el factorial: ");
    var fac = MyMath.Factorial(num);
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"El factorial de: {num} es: {fac:N0}");
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

//double Factorial(int num)
//{
//    var i = 2;
//    double fac = 1;
//    while (i <= num)
//    {
//        fac *= i;
//        i++;
//    }
//    return fac;
//}