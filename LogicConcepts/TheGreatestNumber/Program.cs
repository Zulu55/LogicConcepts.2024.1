using Shared;

do
{
    var a = ConsoleExtension.GetInt("Ingrese primer número : ");
    var b = ConsoleExtension.GetInt("Ingrese segundo número: ");
    var c = ConsoleExtension.GetInt("Ingrese tercer número : ");

    if (a > b && a > c)
    {
        Console.WriteLine($"El número mayor es: {a}");
    }
    else if (b > a && b > c)
    {
        Console.WriteLine($"El número mayor es: {b}");
    }
    else
    {
        Console.WriteLine($"El número mayor es: {c}");
    }
} while (true);