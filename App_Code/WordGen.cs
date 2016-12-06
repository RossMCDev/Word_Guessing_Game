using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class WordGen
{


    public static String[] animals= { "turtle", "owl","spider","platypus","otter"};
    public static String[] plants = { "weed", "flower", "tree", "vine", "moss" };
    public static String[] space = { "supernova", "moon", "galaxy", "star", "comet" };
    public static String[] drinks = { "espresso", "coffee", "tea", "hot chocolate", "latte" };
    public static String[] music = { "sharp", "cord", "melody", "note", "flat" };
    public String[] words;
    public  string word { get; set; }

    public WordGen()
    {
    }

    //random selection of word, can not be the same as the last word, but doesn't need to change index when the category changes;
    public void ChooseWord(string category, int previousWord,string previousCategory)
    {
        Random random = new Random();
        int rannum = random.Next(0, 5);
        if (previousCategory == category)
        {
        while (previousWord == rannum)
        {
            rannum = random.Next(0, 5);
        }}
        word = words[rannum];
    }

    public void ChooseTopic(string category,int previousWord, string previousCategory)
    {
         switch (category) {

            case "Animals":
                words = animals;
                break;
            case "Plants":
                words = plants;
                break;
            case "Space":
                words = space;
                break;
            case "Hot Drinks":
                words = drinks;
                break;
            case "Music Composition":
                words = music;
                break;

        }
         ChooseWord(category, previousWord,previousCategory);
         previousCategory = category;

    }
}