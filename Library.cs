public class Library
{
    private string name;
    private List<Book> books;
    private List<Dvd> dvds;
    private List<User> users;

    public Library(string name)
    {
        this.name = name;
    }

    public List<Book> Books
    {
        get
        {
            return books;
        }
        set
        {
            books = value;
        }
    }

    public List<Dvd> Dvds
    {
        get
        {
            return dvds;
        }
        set
        {
            dvds = value;
        }
    }

    public List<User> Users
    {
        get
        {
            return users;
        }
        set
        {
            users = value;
        }
    }

    public Document GetDocument(string value)
    {
        foreach (Dvd dvd in dvds)
        {
            if (dvd.IdCode == value || dvd.Title.ToLower() == value.ToLower())
            {
                return dvd;
            }
        }
        foreach (Book book in books)
        {
            if (book.IdCode == value || book.Title.ToLower() == value.ToLower())
            {
                return book;
            }
        }
        return new Document();
    }
}
