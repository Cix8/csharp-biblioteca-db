public class Document
{
    protected string idCode;
    protected string title;
    protected int year;
    protected string genre;
    protected bool available;
    protected string shelfCode;
    protected string author;

    public Document()
    {
        this.title = "Vouto";
    }
    public Document(string idCode, string title, int year, string genre, string shelfCode, string author)
    {
        this.idCode = idCode;
        this.title = title;
        this.year = year;
        this.genre = genre;
        this.available = true;
        this.shelfCode = shelfCode;
        this.author = author;
    }

    public string IdCode
    {
        get
        {
            return this.idCode;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }
    }

    public bool Available
    {
        get
        {
            return this.available;
        }
        set
        {
            this.available = value;
        }
    }
}
