using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random rnd = new Random();
        var availableWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && availableWords.Count > 0; i++)
        {
            int index = rnd.Next(availableWords.Count);
            availableWords[index].Hide();
            availableWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string joinedWords = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {joinedWords}";
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
