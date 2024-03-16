namespace Shared
{
    public class ConsoleExtension
    {
        public static int GetInt(string message)
        {
            Console.Write(message);
            var numberString = Console.ReadLine();
            var numberInt = 0;
            if (int.TryParse(numberString, out numberInt))
            {
                return numberInt;
            }

            return 0;
        }
    }
}