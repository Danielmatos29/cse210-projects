public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        string [] splitWords = text.Split(" ");
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int counter = 0;

        while (counter < numberToHide && IsCompletelyHidden() == false)
        {
            int randomNumber = random.Next(0, _words.Count());

            Word newWord = _words[randomNumber];

            if (newWord.IsHidden() == false)
            {
                counter += 1;
                newWord.Hide();  
            }
        }
    }

    public string GetDisplayText()
    {
        string text = "";
        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }

        text = text.TrimEnd();
        return $"{_reference.GetDisplayText()} {text}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                return false;
            }
        }
        return true;
    }
}