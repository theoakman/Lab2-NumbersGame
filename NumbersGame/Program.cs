using System.Diagnostics;
using System.Globalization;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // While loop to make sure you return to the menu when you are done playing the game
            while (true)
            {

                Console.WriteLine(" _   _                 _                 _____                      \r\n| \\ | |               | |               |  __ \\                     \r\n|  \\| |_   _ _ __ ___ | |__   ___ _ __  | |  \\/ __ _ _ __ ___   ___ \r\n| . ` | | | | '_ ` _ \\| '_ \\ / _ \\ '__| | | __ / _` | '_ ` _ \\ / _ \\\r\n| |\\  | |_| | | | | | | |_) |  __/ |    | |_\\ \\ (_| | | | | | |  __/\r\n\\_| \\_/\\__,_|_| |_| |_|_.__/ \\___|_|     \\____/\\__,_|_| |_| |_|\\___|\r\n                                                                    \r\n                                                                    ");
                Console.WriteLine("1. Start Game\n2. Hard Mode\n3. Exit Game");

                // Switch case menu for choosing games difficulty or exiting the program
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        NumberGame(11);
                        break;

                    case "2":
                        NumberGame(101);
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Skriv ett tal mellan 1 och 3!");
                        break;

                }

            }

            static void NumberGame(int difficulty)
            {
                do
                {
                    Console.Clear();
                    Random reply = new Random();
                    string[] toHigh = { "Tyvär, du gissade för högt!", "Det där var för högt!", "Inte högre än det!", "Pro tip: Skriv ett lägre tal" };
                    string[] toLow = { "Tyvär, du gissade för lågt!", "Det där var för lågt!", "Inte lägre än det!", "Pro tip: Skriv ett högre tal" };
                    Random random = new Random();
                    int secretNumber = random.Next(1, difficulty);
                    int atemptsLeft = 5;
                    int guessInput = 0;

                    Console.WriteLine($"Välkommen!\nJag tänker på ett nummer\nKan du gissa vilket? Du får 5 försök!");

                    Console.WriteLine($"Gissa på ett tal mellan 1 och {difficulty - 1}:");


                    // The loop will keep going as long as the user doesent find write the righr number or their number of atmpts run out
                    while (guessInput != secretNumber && atemptsLeft != 0)
                    {

                        string userInput = Console.ReadLine();

                        while (!int.TryParse(userInput, out guessInput))
                        {
                            Console.WriteLine("Du måste skriva ett heltal.\nFörsök igen");
                            userInput = Console.ReadLine();
                        }


                        if (guessInput > secretNumber)
                        {
                            atemptsLeft--;
                            if (atemptsLeft != 0) //Stops the messege from being sent out after your last atempt
                            {
                                Console.WriteLine(toHigh[reply.Next(toHigh.Length)]);
                                Console.WriteLine($"Du har {atemptsLeft} försök kvar");
                            }

                            if (Math.Abs(guessInput - secretNumber) <= 1 && atemptsLeft != 0)
                            {
                                Console.WriteLine("Men det bräns!");
                            }
                            else if (Math.Abs(guessInput - secretNumber) <= 4 && atemptsLeft != 0)
                            {
                                Console.WriteLine("Det var ganska nära");
                            }
                            else if (Math.Abs(guessInput - secretNumber) <= 10 && atemptsLeft != 0)
                            {
                                Console.WriteLine("Du är på rätt håll");
                            }

                        }

                        else if (guessInput < secretNumber)
                        {
                            atemptsLeft--;
                            if (atemptsLeft != 0) //Stops the messege from being sent out after your last atempt (Again)
                            {
                                Console.WriteLine(toLow[reply.Next(toLow.Length)]);
                                Console.WriteLine($"Du har {atemptsLeft} försök kvar");
                            }

                            if (Math.Abs(guessInput - secretNumber) <= 1 && atemptsLeft != 0)
                            {
                                Console.WriteLine("Men det bräns!");
                            }
                            else if (Math.Abs(guessInput - secretNumber) <= 4 && atemptsLeft != 0)
                            {
                                Console.WriteLine("Det var ganska nära");
                            }
                            else if (Math.Abs(guessInput - secretNumber) <= 10 && atemptsLeft != 0)
                            {
                                Console.WriteLine("Du är på rätt håll");
                            }

                        }

                    }


                        // After the game is over the program tells the player if the won or lost the game

                        if (atemptsLeft == 0)
                        {
                            Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på fem försök!\nTalet var {secretNumber}");
                        }
                        else
                        {
                            Console.WriteLine("                                         ,---.                                                         \r\n,--.   ,--.       ,--.                   |   |                                                         \r\n|  |   |  | ,---. |  ,---.  ,---.  ,---. |  .'                                                         \r\n|  |.'.|  || .-. ||  .-.  || .-. || .-. ||  |                                                          \r\n|   ,'.   |' '-' '|  | |  |' '-' '' '-' '`--'                                                          \r\n'--'   '--' `---' `--' `--' `---'  `---' .--.                                                    ,---. \r\n,------.              ,--.    ,--.       '--'               ,--.              ,--.         ,--.  |   | \r\n|  .-.  \\ ,--.,--.    |  |,-. |  | ,--,--.,--.--. ,--,--. ,-|  | ,---.      ,-|  | ,---. ,-'  '-.|  .' \r\n|  |  \\  :|  ||  |    |     / |  |' ,-.  ||  .--'' ,-.  |' .-. || .-. :    ' .-. || .-. :'-.  .-'|  |  \r\n|  '--'  /'  ''  '    |  \\  \\ |  |\\ '-'  ||  |   \\ '-'  |\\ `-' |\\   --.    \\ `-' |\\   --.  |  |  `--'  \r\n`-------'  `----'     `--'`--'`--' `--`--'`--'    `--`--' `---'  `----'     `---'  `----'  `--'  .--.  \r\n                                                                                                 '--'  ");

                        }

                        string answer;
                        do
                        {
                            Console.WriteLine("Vill du spela igen?\nSkriv \"ja\" eller \"nej\" ");
                            answer = Console.ReadLine();

                            if (answer != "ja" && answer != "nej")
                            {
                                Console.WriteLine("Ojiltigt svar");
                            }

                        } while (answer != "ja" && answer != "nej");

                        if (answer == "ja")
                        {
                            Console.Clear();
                        }
                        else if (answer == "nej")
                        {
                            Console.Clear();
                            break;
                        }


                    

                } while (true);


            }
        }
    }
}