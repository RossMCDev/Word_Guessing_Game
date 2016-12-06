using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class WordGuess
{
    public  int guesscounter { get; set; }
    public  string wordprogress { get; set; }
    public  List<char> letters = new List<char>();
    public  List<char> missedletters = new List<char>();
    public WordGen theWord;


    public WordGuess()
    {

    }

    public  void MakeGuess(char guess)
    {
        guesscounter++;
        letters.Add(guess);
    }

    public void ResetCounter()
    {
        guesscounter = 0;
    }

    public void WordLength(WordGen theWord)
    {
        string worldlength = "";
        int lettercount = 1;
        foreach (char letter in theWord.word)
        {

            if (letter == ' ') 
            {
                worldlength = worldlength + "&nbsp;";
            }
            else
            {
            if (lettercount == theWord.word.Length)
            {
                worldlength = worldlength + "_";
            }


            else
            {
                worldlength = worldlength + "_ ";

            }
            }
            lettercount++;
        }

        wordprogress = worldlength;
    }

    public  string DisplayMissedLetters()
    {
        string misssed = "";

        foreach (char l in missedletters)
        {
            misssed = misssed + l + " ";
        }
        return "Letter Bin: " + misssed;
    }
}
