using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var weigth = ConsoleExtension.GetFloat("Peso de la mercancía.............: ");
    var value = ConsoleExtension.GetDecimal("Valor de la mercancía............: ");
    string isMonday;
    do
    {
        isMonday = ConsoleExtension.GetValidOptions("Es lunes [S]í, [N]o..............: ", options)!;
    } while (!options.Any(x => x.Equals(isMonday, StringComparison.CurrentCultureIgnoreCase)));

    var payMethods = new List<string> { "e", "t" };
    string payMethod;
    do
    {
        payMethod = ConsoleExtension.GetValidOptions("Tipo de pago [E]fectivo [T]arjeta: ", payMethods)!;
    } while (!payMethods.Any(x => x.Equals(payMethod, StringComparison.CurrentCultureIgnoreCase)));

    var fare = CalculateFare(weigth);
    var discount = CalculateDiscount(fare, value);
    decimal promotion = 0;
    if (discount == 0)
    {
        promotion = CalculatePromotion(fare, isMonday, payMethod, value);
    }

    Console.WriteLine($"Tarifa...........................: {fare,20:C2}");
    Console.WriteLine($"Descuento........................: {discount,20:C2}");
    Console.WriteLine($"Promoción........................: {promotion,20:C2}");
    Console.WriteLine($"Total a pagar....................: {fare - discount - promotion,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");

decimal CalculatePromotion(decimal fare, string isMonday, string payMethod, decimal value)
{
    if (isMonday.ToLower() == "s" && payMethod.ToLower() == "t")
    {
        return fare * 0.5m;
    }

    if(payMethod.ToLower() == "e" && value > 1000000m)
    {
        return fare * 0.4m;
    }

    return 0;
}

decimal CalculateDiscount(decimal fare, decimal value)
{
    if (value >= 300000m && value <= 600000m)
    {
        return fare * 0.1m;
    }
    if (value > 600000m && value <= 1000000m)
    {
        return fare * 0.2m;
    }
    if (value >= 1000000m)
    {
        return fare * 0.3m;
    }
    return 0;
}

decimal CalculateFare(float weigth)
{
    if (weigth <= 100)
    {
        return 20000m;
    }
    if (weigth <= 150)
    {
        return 25000m;
    }
    if (weigth <= 200)
    {
        return 30000m;
    }
    int aditional = ((int)weigth - 200) / 10;
    return 35000m + aditional * 2000m;
}

