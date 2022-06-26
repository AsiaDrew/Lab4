


string pigLatinSentence = "";
Console.WriteLine("Pig Latin Translator");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Please enter a word or a phrase to translate into Pig Latin");
    string userWord = Console.ReadLine().ToLower();
    Console.WriteLine();
    pigLatinSentence = TranslateSentence(userWord);
    Console.WriteLine($"In Pig Latin that translate to: {pigLatinSentence}");
    Console.WriteLine();



    Console.WriteLine("Do u want to translate another word or phrase? Enter y/n");
    string userChoice = Console.ReadLine().ToLower();
    if (userChoice == "y")
    {
        continue;
    }
    else
    {
        break;
    }
}
return;



//methods

//create pig latin word
static string PigLatin(string word)
{
    string PigLatinWord = "";
    int vowelPosition = 0;
    int counter = 0;
    char letter = word[0];
    bool hasVowels = true;
    const string WAY = "way";
    const string AY = "ay";
    const string VOWEL = "aeiou";
    const string Y = "y";

    vowelPosition = VOWEL.IndexOf(letter);

    while (vowelPosition == -1 && counter <= word.Length)
    {
        if (vowelPosition == -1 && counter < word.Length)
        {
            counter++;
            letter = word[counter - 1];
            vowelPosition = VOWEL.IndexOf(letter);
            hasVowels = true;
        }
        else
        {
            counter++;

            hasVowels = false;
        }
    }
    letter = word[0];
    vowelPosition = VOWEL.IndexOf(letter);
    if (vowelPosition != -1)
    {
        PigLatinWord = word + WAY;
    }
    else if (hasVowels)
    {
        counter = 0;
        while (vowelPosition == -1 && counter < word.Length)
        {
            counter++;

            letter = word[counter];
            vowelPosition = VOWEL.IndexOf(letter);
        }
        PigLatinWord = word.Substring(counter) + word.Substring(0, counter) + AY;
    }
    else
    {
        counter = 0;
        while (vowelPosition == -1 && counter < word.Length)
        {
            counter++;
            letter = word[counter];
            vowelPosition = Y.IndexOf(letter);
        }
        PigLatinWord = word.Substring(counter) + word.Substring(0, counter) + AY;
    }
    return PigLatinWord;
}

//string pig latin word into a sentence
static string TranslateSentence(string sentence)
{
    string newSentence = "";
    string[] allWords = sentence.ToLower().Split(' ');

    foreach (string word in allWords)
    {
        newSentence += PigLatin(word);
        newSentence += " ";
    }
    return newSentence;
}