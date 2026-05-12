using Class02.Homework.Domain.Interfaces;

namespace Class02.Homework.Domain.Models;

public class Documents : ISearchable
{
    public string Title { get; set; }
    public string Content { get; set; }

    // Search inside Content, ignoring letter case.
    // IndexOf returns a position if found, otherwise -1.
    //Index of has 11 or so overloads might come in handy
    public bool Search(string word)
    {
        if (Content.IndexOf(word, StringComparison.OrdinalIgnoreCase) >=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
