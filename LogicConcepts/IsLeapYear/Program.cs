using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var currentYear = DateTime.Now.Year;
    var message = string.Empty;
    var year = ConsoleExtension.GetInt("Ingrese año: ");

    if (year == currentYear)
    {
        message = "es";
    } else if(year > currentYear)
    {
        message = "va a ser";
    }
    else
    {
        message = "fue";
    }


    if ( year % 4 == 0)
    {
        if (year % 100 == 0 )
        {
            if ( year % 400 == 0)
            {
                Console.WriteLine($"El año: {year}, SI {message} biciesto.");
            }
            else
            {
                Console.WriteLine($"El año: {year}, NO {message} biciesto.");
            }
        }
        else
        {
            Console.WriteLine($"El año: {year}, SI {message} biciesto.");
        }
    }
    else
    {
        Console.WriteLine($"El año: {year}, NO {message} biciesto.");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");