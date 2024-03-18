using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var name = ConsoleExtension.GetString("Ingrese nombre......................: ");
    var workHours = ConsoleExtension.GetFloat("Ingrese número de horas trabajadas..: ");
    var hourValue = ConsoleExtension.GetDecimal("Ingrese valor hora..................: ");
    var salaryMimimun = ConsoleExtension.GetDecimal("Ingrese valor salario mínimo mensual: ");

    var salary = (decimal)workHours * hourValue;
    if (salary < salaryMimimun)
    {
        Console.WriteLine($"Nombre..............................: {name}");
        Console.WriteLine($"Salario.............................: {salaryMimimun:C2}");
    }
    else
    {
        Console.WriteLine($"Nombre..............................: {name}");
        Console.WriteLine($"Salario.............................: {salary:C2}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");