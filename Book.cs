public class Book : Document
{
    private int pages;
    public Book(string isbn, int pages, string title, int year, string genre, string shelfCode, string author) : base(isbn, title, year, genre, shelfCode, author)
    {
        this.pages = pages;
    }
}
