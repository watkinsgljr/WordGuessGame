using System;
using System.Collections.Generic;


public class Word
{

    public string CurrentWord { get; set; }
    public List<Letter> Letters { get; set; }
    public string Display { get; set; }
    public int Chances { get; set; }

    //Constructor--------------------------------------------
    public Word(string word)
	{
        this.CurrentWord = word;
        this.Letters = new List<Letter>();
        this.Display = "_";
        this.Chances = word.Length + 3;
    }

    public void GenerateLetterList(string currentWord)
    {
        for (int i = 0; i < currentWord.Length; i++)

        {     
            Letters.Add(new Letter(currentWord[i].ToString()));
        }

    }

    public void CheckUserGuess(string userInput)
    {
        foreach (var Letter in Letters)
        {
            Letter.CheckGuess(userInput);
        }
    }

    public int GetLettersRemaining()
    {
        int LettersRemaining = 0;
        foreach (var Letter in Letters)
        {
            if (Letter.WasGuessed == false)
            {
                LettersRemaining += 1;
            }
        } return LettersRemaining;
    }




}


