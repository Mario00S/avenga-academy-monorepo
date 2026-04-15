# Library brief

## Create a Library Management app

The app will have users that can log in and perform some actions. The user can choose one of the 3 roles and log in:

- Admin
- Librarian
- Member (has current borrowed book and history of previously returned books and how many days the member kept the book)

After logging in there should be different options for different roles:

- Admins can add/remove Librarians, Members, and other Admins (can't remove itself)
- Librarian can choose between seeing all members and all books
- When choosing Members, all member names should appear
- When choosing a name, it should print all the borrowed books from the past and the currently boroowed book
- When choosing Books, all book names appear with how many members have borrowed them next to it
- Members are shown the names of the books they have borrowed and the remaining days for each one