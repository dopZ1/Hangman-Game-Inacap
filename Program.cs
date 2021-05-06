using System;

namespace ProgAvanzada01
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] words = { "sandia", "mano", "mouse", "telefono", "monitor", "atrapar", "viaje", "bacteria", "calvo", "navidad", "aplauso", "pizza", "dormir", "fideos", "huella" };
            char[] letters = "abcdefghijklmnñopqrstuvwxyz".ToCharArray();
            int trys = 5;
            string word = words[rnd.Next(words.Length)];
            char[] guess = new char[word.Length];

            for (int i = 0; i < guess.Length; i++)
            {
                guess[i] = '_';
            }

            Console.WriteLine($"-----------* Juego del Colgado *-----------\nTienes {trys} intentos.\nBuena Suerte!");

            do
            {
                Console.Write("\nIngresa una Letra: ");
                char input = Console.ReadLine()[0];

                if (IsLetter(input, letters))
                {
                    if (word.Contains(input))
                    {
                        if (!IsRepeated(input, guess))
                        {
                            Console.WriteLine("\n" + new String(Hint(input, word, guess)));
                            if (IsCompleted(word, guess))
                                break;
                        }
                        else
                        {
                            Console.WriteLine("\nYa ingresaste esta letra");
                        }
                    }
                    else
                    {
                        trys--;
                        Console.WriteLine($"\nFallaste, te quedan {trys} intentos.");

                        if (trys == 0)
                        {
                            Console.WriteLine($"\nHas perdido, la palabra era {word}.");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nSimbolos y Numeros no permitidos.");
                }

            } while (trys >= 0);
        }

        private static bool IsLetter(char input, char[] letters)
        {
            bool isLetter = false;
            foreach (char letter in letters)
            {
                if (input.Equals(letter))
                {
                    isLetter = true;
                }
            }
            return isLetter;
        }

        private static bool IsRepeated(char input, char[] guess)
        {
            bool repeated = false;

            for (int i = 0; i < guess.Length; i++)
            {
                if (input.Equals(guess[i]))
                {
                    repeated = true;
                }
            }
            return repeated;
        }

        private static bool IsCompleted(string word, char[] guess)
        {
            bool completed = false;
            if (word.Equals(new String(guess)))
            {
                Console.WriteLine($"\nFelicidades has ganado! La palabra era {word}.");
                completed = true;
            }
            return completed;
        }

        private static char[] Hint(char input, string word, char[] guess)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (input.Equals(word[i]))
                {
                    guess[i] = input;
                }
            }
            return guess;
        }
    }
}