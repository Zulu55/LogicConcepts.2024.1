using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("*** DATOS DE ENTRADA ***");
    var CC = ConsoleExtension.GetDecimal("Costo de compra ($)....................................................: ");

    var tpOptions = new List<string> { "p", "n" };
    var TP = string.Empty;
    do
    {
        TP = ConsoleExtension.GetValidOptions("Tipo de producto [P]erecedero, [N]o perecedero.........................: ", tpOptions);
    } while (!tpOptions.Any(x => x.Equals(TP, StringComparison.CurrentCultureIgnoreCase)));

    var tcOptions = new List<string> { "f", "a" };
    var TC = string.Empty;
    do
    {
        TC = ConsoleExtension.GetValidOptions("Tipo de conservación [F]rio, [A]mbiente................................: ", tcOptions);
    } while (!tcOptions.Any(x => x.Equals(TC, StringComparison.CurrentCultureIgnoreCase)));

    var PC = ConsoleExtension.GetInt("Periodo de conservación (días).........................................: ");
    var PA = ConsoleExtension.GetInt("Periodo de almacenamiento (días).......................................: ");
    var VOL = ConsoleExtension.GetInt("Volumen (litros).......................................................: ");

    var maOptions = new List<string> { "n", "c", "e", "g" };
    var MA = string.Empty;
    do
    {
        MA = ConsoleExtension.GetValidOptions("Medio de almacenamiento [N]evera, [C]ongelador, [E]estanteria, [G]uacal: ", maOptions);
    } while (!maOptions.Any(x => x.Equals(MA, StringComparison.CurrentCultureIgnoreCase)));

    Console.WriteLine("*** CALCULOS ***");
    var CA = GetCostoAlmacenamiento(TP, CC, TC, PC, VOL);
    var PDP = GetPorcentajeDeprecicionDelProducto(PA);
    var CE = GetCostoExhibicion(TP, TC, MA, CA);
    var VR_P = GetValorProducto(CC, CA, CE, PDP);
    var VR_V = GetValorVenta(VR_P, TP);

    // Show results
    Console.WriteLine($"Costos de almacenamiento..............................................: {CA,20:C2}");
    Console.WriteLine($"Porcentaja de depreciación............................................:  {PDP,20:P2}");
    Console.WriteLine($"Costo de exhibición...................................................: {CE,20:C2}");
    Console.WriteLine($"Valor producto........................................................: {VR_P,20:C2}");
    Console.WriteLine($"Valor venta...........................................................: {VR_V,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Game Over.");

decimal GetValorVenta(decimal VR_P, string? TP)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        return VR_P * 1.4m;
    }

    return VR_P * 1.2m;
}

decimal GetValorProducto(decimal CC, decimal CA, decimal CE, float PDP)
{
    return (CC + CA + CE) * (decimal)PDP;
}

decimal GetCostoExhibicion(string? TP, string? TC, string? MA, decimal CA)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if (TP!.Equals("f", StringComparison.CurrentCultureIgnoreCase))
        {
            if (MA!.Equals("n", StringComparison.CurrentCultureIgnoreCase))
            {
                return CA * 2;
            }

            return CA;
        }
    }

    if (MA!.Equals("e", StringComparison.CurrentCultureIgnoreCase))
    {
        return CA * 0.05m;
    }

    return CA * 0.07m;
}

float GetPorcentajeDeprecicionDelProducto(int PA)
{
    if (PA < 30)
    {
        return 0.95f;
    }

    return 0.85f;
}

decimal GetCostoAlmacenamiento(string? TP, decimal CC, string? TC, int PC, int VOL)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if (TC!.Equals("f", StringComparison.CurrentCultureIgnoreCase))
        {
            if (PC < 10)
            {
                return CC * 0.05m;
            }

            return CC * 0.1m;
        }

        if (PC < 20)
        {
            return CC * 0.03m;
        }

        if (PC > 20)
        {
            return CC * 0.1m;
        }

        return CC * 0.05m;
    }

    if (VOL >= 50)
    {
        return CC * 0.1m;
    }

    return CC * 0.2m;
}