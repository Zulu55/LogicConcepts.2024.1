using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** FRANSES PALINDROMAS ***");
    var phrase = ConsoleExtension.GetString("Ingrese la palabra o frase? ");

    // Do process
    var isPalindrome = IsPalindrome(phrase);

    // Show results
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine($"La palabra o frase '{phrase}' {(isPalindrome ? "Si" : "No")} es palíndrome.");

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

bool IsPalindrome(string? phrase)
{
    phrase = PreparePhrase(phrase);

    var n = phrase!.Length;
    for (var i = 0; i < n / 2; i++)
    {
        if (phrase[i] != phrase[n - i - 1])
        {
            return false;
        }
    }
    return true;
}

string? PreparePhrase(string? phrase)
{
    phrase = phrase!.ToLower();
    var newPhrase = string.Empty;
    var expetions = new List<char> { ' ', ',', '.', '!', '¡', '?', '¿', ':', ';' };

    foreach (var character in phrase)
    {
        if (!expetions.Contains(character))
        {
            if (character == 'á') newPhrase += 'a';
            else if (character == 'é') newPhrase += 'e';
            else if (character == 'í') newPhrase += 'i';
            else if (character == 'ó') newPhrase += 'o';
            else if (character == 'ú') newPhrase += 'u';
            else newPhrase += character;
        }
    }
    return newPhrase;
}