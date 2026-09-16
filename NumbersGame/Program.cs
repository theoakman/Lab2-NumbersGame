namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök!");

            Console.WriteLine(NumberGame(0, 0));

          }

        static string NumberGame(int guess, int secret)
        {
            Random random = new Random();
            secret = random.Next(1, 20);

            Console.WriteLine("Gissa ett tal:");

            int atempts = 0;

            while (guess != secret && atempts != 5)
            {
                string userInput = Console.ReadLine();
                guess = int.Parse(userInput);
                if (guess > secret)
                {
                    Console.WriteLine("Tyvärr, du gissade för högt!");
                    atempts++;
                }
                else if (guess < secret)
                {
                    Console.WriteLine("Tyvärr, du gissade för lågt!");
                    atempts++;
                }
            }
            if (atempts == 5)
            {
                return "Tyvärr, du lyckades inte gissa talet på fem försök!";
            }
            else
            return "Wohoo! Du klarade det!";

        }
    }
}
