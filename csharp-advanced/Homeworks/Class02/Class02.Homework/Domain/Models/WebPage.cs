using Class02.Homework.Domain.Interfaces;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Class02.Homework.Domain.Models;

public class WebPage : ISearchable
{
    public string Url { get; set; }
    public string Html { get; set; }

    public bool Search(string word)
    {
        // "<.*?>" matches HTML tags like <p>, </p>, <b> and removes them.
        string cleanHtml = Regex.Replace(Html, "<.*?>", "");
        if (cleanHtml.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
