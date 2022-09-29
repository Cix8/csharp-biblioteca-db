using Microsoft.Data.SqlClient;

public class Library
{
    public static string connectionString = "Data Source=localhost;Initial Catalog=db-library;Integrated Security=True;Encrypt=False";
    
    private string name;
    private List<Book> books;
    private List<Dvd> dvds;
    private List<User> users;

    public Library(string name)
    {
        this.name = name;

        this.books = new List<Book>();
        this.dvds = new List<Dvd>();
        this.users = new List<User>();

        SqlConnection sqlConnection = new SqlConnection(Library.connectionString);

        try
        {
            sqlConnection.Open();

            string query = "SELECT * FROM books";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int id = reader.GetInt32(0);
                string isbn = reader.GetString(1);
                int pages = reader.GetInt32(2);
                string title = reader.GetString(3);
                int year = reader.GetInt32(4);
                string genre = reader.GetString(5);
                string shelfCode = reader.GetString(6);
                string author = reader.GetString(7);

                Book thisBook = new Book(isbn, pages, title, year, genre, shelfCode, author);
                this.books.Add(thisBook);
            }
            reader.Close();

            query = "SELECT * FROM dvds";
            cmd = new SqlCommand(query, sqlConnection);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int id = reader.GetInt32(0);
                string serial_number = reader.GetString(1);
                int duration_in_minutes = reader.GetInt32(2);
                string title = reader.GetString(3);
                int year = reader.GetInt32(4);
                string genre = reader.GetString(5);
                string shelfCode = reader.GetString(6);
                string author = reader.GetString(7);

                Dvd thisDvd = new Dvd(serial_number, duration_in_minutes, title, year, genre, shelfCode, author);
                this.dvds.Add(thisDvd);
            }
            reader.Close();
        } 
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        } 
        finally
        {
            sqlConnection.Close();
        }
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
