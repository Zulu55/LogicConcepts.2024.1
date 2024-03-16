using Shared;

do
{
    var a = ConsoleExtension.GetInt("Ingrese primer número : ");
    var b = ConsoleExtension.GetInt("Ingrese segundo número: ");
    if (b % a == 0)
    {
        Console.WriteLine($"{a} es múltiplo {b}");
    }
    else
    {
        Console.WriteLine($"{a} no es múltiplo {b}");
    }
} while (true);