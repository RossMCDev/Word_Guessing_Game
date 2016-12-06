using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  

    
    }
protected void ButtonGuess_Click(object sender, EventArgs e)
    {
        WordGuess wordguess = new WordGuess();
        wordguess = (WordGuess)Session["wordguess"];


        LabelStatus.Text = "";
        wordguess.wordprogress = "";

        try
        { 
        char guessletter = TextBoxGuess.Text.ToLower().First();
        if (!wordguess.letters.Contains(guessletter))
        {
                wordguess.letters.Add(guessletter);
                GenerateWordDisplay(wordguess);

            if (!wordguess.theWord.word.Contains(guessletter))
            { wordguess.guesscounter++; }




            if (wordguess.wordprogress == wordguess.theWord.word)
            {
                    ReStart();

                    LabelStatus.Text = "You win!";
            }

            ImageBase.ImageUrl = "~/Images/State" + wordguess.guesscounter + ".png";

            if (wordguess.guesscounter > 5)
            {
                AutoGenerateWordDisplay(wordguess);
                    ReStart();
                    LabelStatus.Text = "You Lose";
            }
            LabelMissWords.Text = wordguess.DisplayMissedLetters();
        }
        else {
            LabelStatus.Text = "You already gave that letter";
        }
            }
    catch(Exception)
        {
            LabelStatus.Text = "Please enter a letter";
    }
        TextBoxGuess.Text = "";
    }

    protected void ButtonStart_Click(object sender, EventArgs e)
    {
        int previousword = 0;
        string previouscategory = "Animals";
        if (Session["previousword"] != null)
        { 
             previousword = (int)Session["previousword"];
        }
        if (Session["previousword"] != null)
        {
            previouscategory = (string)Session["previouscategory"];
        }

        WordGuess wordguess = new WordGuess();
        WordGen word = new WordGen();
        wordguess.theWord = word;
        wordguess.theWord.ChooseTopic(DropDownListCategories.SelectedValue, previousword, previouscategory);
        Session["previousword"] = wordguess.theWord.words.ToList().FindIndex(a => a == wordguess.theWord.word);
        Session["previouscategory"] = DropDownListCategories.SelectedValue;
        wordguess.letters.Clear();
        wordguess.missedletters.Clear();
        LabelMissWords.Text = wordguess.DisplayMissedLetters();
        wordguess.ResetCounter();
        wordguess.WordLength(wordguess.theWord);
        ImageBase.ImageUrl = "~/Images/State" + 0 +".png";
        ButtonGiveUp.Visible = true;
        TextBoxGuess.Visible = true;
        ButtonGuess.Visible = true;
        LabelWordToGuess.Visible = true;
        LabelWordToGuess.Text = "";
        LabelWordToGuess.Text = wordguess.wordprogress;
        LabelMissWords.Visible = true;
        LabelStatus.Text = "";
        LabelCategories.Visible = false;
        DropDownListCategories.Visible = false;
        ButtonStart.Visible = false;
        Session["wordguess"] = wordguess;
    }


    protected void ButtonGiveUp_Click(object sender, EventArgs e)
    {
        WordGuess wordguess = new WordGuess();
        wordguess = (WordGuess)Session["wordguess"];

        ImageBase.ImageUrl = "~/Images/State" + 6 + ".png";
        AutoGenerateWordDisplay(wordguess);
        ReStart();
        LabelStatus.Text = "You Lose";
    }



    public void ReStart()
    {
        ButtonStart.Text = "Play Again";
        LabelCategories.Visible = true;
        DropDownListCategories.Visible = true;
        ButtonStart.Visible = true;
        ButtonGiveUp.Visible = false;
        TextBoxGuess.Visible = false;
        ButtonGuess.Visible = false;
    }

    public void GenerateWordDisplay(WordGuess wordguess)
    {

        string wordprogressdisplay = "";

        bool lettermatch = false;
        //first letter of secound word 
        bool twofirst = false;
        int lettercount = 1;

        foreach (char letter in wordguess.theWord.word)
        {

            if (letter == ' ') 
            {
                 twofirst = true;
                wordguess.wordprogress = wordguess.wordprogress + ' ';
                 wordprogressdisplay = wordprogressdisplay + "&nbsp;";

            }

            else { 
            foreach (char givenletter in wordguess.letters)
            {
                if (letter == givenletter)
                {
                    char displayletter = givenletter;
                    if (lettercount == 1 || twofirst)
                    {
                        displayletter = displayletter.ToString().ToUpper().First();
                    }
                    if (lettercount == wordguess.theWord.word.Length)
                    {
                    wordprogressdisplay = wordprogressdisplay + displayletter;
                    }
                    else
                    {
                    wordprogressdisplay = wordprogressdisplay + displayletter + " ";
                    }
                        wordguess.wordprogress = wordguess.wordprogress + givenletter;
                    lettermatch = true;
                }
                else
                {
                    if (!wordguess.missedletters.Contains(givenletter) && !wordguess.theWord.word.Contains(givenletter))
                    {
                            wordguess.missedletters.Add(givenletter);
                    }
                }
            }
            twofirst = false;

            if (!lettermatch)
            {
                if (lettercount == wordguess.theWord.word.Length)
                {
                    wordprogressdisplay = wordprogressdisplay + "_";
                }
                else
                {
                    wordprogressdisplay = wordprogressdisplay + "_ ";
                }
            }
            lettermatch = false;
            }
            lettercount++;
        }
        LabelWordToGuess.Text = wordprogressdisplay;

    }

    public void AutoGenerateWordDisplay(WordGuess wordguess)
    {
        wordguess.letters.Clear();
        foreach (char letter in wordguess.theWord.word)
        {
            if (!wordguess.letters.Contains(letter))
            {
                wordguess.letters.Add(letter);
            }
        }
        GenerateWordDisplay(wordguess);
    }
}
