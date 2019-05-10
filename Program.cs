using System;
using System.Collections.Generic;


namespace WordGuessGame
{
    public class Program

    {
        static void Main(string[] args)
        {
            Greeting();
            Word CurrentWordObj = NewGameInit();
            GamePlay(CurrentWordObj);
            

        }




        public static string CaptureWord()
        {
            Random r = new Random();
            string[] wordBank = { "man", "rat", "cow", "chicken" };
            return wordBank[r.Next(0, wordBank.Length)];
        }

        public static Word NewGameInit()
        {     
            string randomWord = CaptureWord();
            Word WordObj = new Word(randomWord);
            WordObj.GenerateLetterList(randomWord);
            return WordObj;
        }

        public static void Greeting()
        {
            string name;
            Console.WriteLine("Welcome to the Word Guess Game!  Would you like to play now?");
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("What's up {0}! Let's play!", name);
            
        }

        public static void ManageUserGuess(Word CurrentWordObj)
        {
            string userGuess = Console.ReadLine();
            if (CurrentWordObj.Chances > 0)
            {
                CurrentWordObj.Chances --;
                CurrentWordObj.CheckUserGuess(userGuess);
            }
              
        }

        public static void LoadDash(Word WordObj)
        {
            var wordDisplay = new List<string>();
            string letterDisplay;
            foreach (Letter letter in WordObj.Letters)
            {
                letterDisplay = letter.ShowLetter();
                wordDisplay.Add(letterDisplay);
            }
              var result = String.Join(" ", wordDisplay);
              PrintStats(WordObj);
              Console.WriteLine("\n" + result);
        }

        public static void  ManageGameState(Word WordObj)
        {
            int LettersRemaining = WordObj.GetLettersRemaining();
            if (WordObj.Chances > 0 && LettersRemaining > 0)
            {
                GamePlay(WordObj);
            } else if (WordObj.Chances > 0 && LettersRemaining == 0)
            {
                UserWins(WordObj);
            } else if (WordObj.Chances == 0 && LettersRemaining == 0)
            {
                UserWins(WordObj);
            }
            else if (WordObj.Chances == 0 && LettersRemaining > 0)
            {
                UserLoses(WordObj);
            }
        }


        public static void PrintStats(Word WordObj)
        {
            int LettersRemaining = WordObj.GetLettersRemaining();
            Console.WriteLine("\n \nGuesses Remaining: {0} | Letters Remaining: {1}", WordObj.Chances, LettersRemaining);
        }

        public static void UserWins(Word WordObj)
        {
            Console.WriteLine("\n \nGood Job!! You guessed '{0}' correctly!", WordObj.CurrentWord);
            PlayAgain();
        }

        public static void UserLoses(Word WordObj)
        {
            Console.WriteLine("\n \nSorry, you lose.  The correct answer is '{0}'", WordObj.CurrentWord);
            PlayAgain();
        }


        public static void PlayAgain()
        {
            Console.WriteLine("\n \nWould you like to play again? Type 'y' or 'n'");
            string playAgain = Console.ReadLine();
            if (playAgain == "Y" || playAgain == "y")
            {
                Console.WriteLine("Let's keep it going!");
                Word CurrentWordObj = NewGameInit();
                GamePlay(CurrentWordObj);
            } else
            {
                Console.WriteLine("\n \nThanks for playing.  See you next time!!");
            }
        }

        public static void GamePlay(Word CurrentWordObj)
        {
            LoadDash(CurrentWordObj);
            ManageUserGuess(CurrentWordObj);
            ManageGameState(CurrentWordObj);
        }
    }
}
