using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Cuantos números desea? ");
    double sum = 0;

    //var i = 1;
    //while (i <= n)
    //{
    //    sum += i;
    //    Console.Write($"{i,10:N0}");
    //    i++;
    //}

    for (var i = 1; i <= n; i++)
    {
        sum += i;
        Console.Write($"{i,10:N0}");
    }

    Console.WriteLine();
    Console.WriteLine($"La sumatoria es: {sum,20:N0}");
    Console.WriteLine($"El promedio es :   {sum / n,20:N1}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));