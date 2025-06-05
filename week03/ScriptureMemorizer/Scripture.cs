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

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference}: {text}";
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        List<int> visibleIndexes = _words.Select((w, i) => new { w, i })
                                         .Where(x => !x.w.IsHidden())
                                         .Select(x => x.i)
                                         .ToList();

        // If there aren't enough visible words left, hide all of them
        count = Math.Min(count, visibleIndexes.Count);
        for (int i = 0; i < count; i++)
        {
            int randIdx = rand.Next(visibleIndexes.Count);
            int wordIdx = visibleIndexes[randIdx];
            _words[wordIdx].Hide();
            visibleIndexes.RemoveAt(randIdx);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
