using Library.Domain;
using Library.Domain.Models;

namespace Library.Services.Services;

public class MemberService
{

    private DataAccess _dataAccess;

    public MemberService()
    {
        _dataAccess = new DataAccess();
    }


    public Member? MemberLogin(string username, string password)
    {
        Member? memberFromDb = _dataAccess.GetMember(username, password);
        if (memberFromDb == null)
        {
            throw new Exception("Invalid credentials. Try Again!");
        }
        return memberFromDb;
    }

    public string CurrentBook(Member loggedMember)
    {
        return loggedMember.CurrentlyBorrowedBook;
    }

    public Dictionary<string, int> HistoryOfBooks(Member loggedMember)
    {
        return loggedMember.ReturnedBooksDaysKept;
    }

}
