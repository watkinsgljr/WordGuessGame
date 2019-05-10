using System;

public class Letter
{
    public string Placeholder { get; set; }
    public bool WasGuessed { get; set; }
    public string CorrectLetter { get; set; }
    public Letter(string correctLetter) 
	{
        this.Placeholder = "_";
        this.CorrectLetter = correctLetter;
	}



    public string ShowLetter()
    {
        if (WasGuessed == false)
        {
            return this.Placeholder;

        } else
        {
            return this.CorrectLetter;
        }
    }



    public void CheckGuess(string guess)
    {
        if (guess == this.CorrectLetter)
        {
            this.WasGuessed = true;
        }
    }



}