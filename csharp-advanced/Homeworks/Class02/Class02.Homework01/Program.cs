//Task #1 - Searchable
//Create an interface Searchable with a method:

//bool Search(string word);
//The method returns true if word appears in the object's content, false otherwise (case-insensitive).
//Create two classes that implement Searchable:
//Document - has a Title and a Content field (both string). Search looks inside Content.
//WebPage - has a Url and an Html field (both string). Search looks inside Html, ignoring HTML tags (a simple Regex.Replace(html, "<.*?>", "") is enough).
//In Program.cs, create one Document and one WebPage, call Search on each with a word that exists and one that doesn't, and print the results.

using Class02.Homework.Domain.Models;
using System.Reflection.Metadata;

Console.WriteLine("The results from the method from the Documents:");
Documents newDocument = new Documents
{
    Title = "Document Test",
    Content = "Document Content"
};
//expected to fail not equal to content
bool result = newDocument.Search("Test");
Console.WriteLine(result);
Console.ReadLine();

WebPage webPage = new WebPage
{
    Url = "test123.com",
    Html = "<p>This is a test<p>"    
};
Console.WriteLine("The results from the WebPage search method");
//expected to pass equal to html
bool resultWebPage = webPage.Search("test");
Console.WriteLine(resultWebPage);
Console.ReadLine();