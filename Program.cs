using Microsoft.Data.SqlClient;

#region Riempio la lista users

Library myLibrary = new Library("Biblioteca Nazionale");

User testUser1 = new User("Nat", "Frank", "frank.nat@email.it", "frankfrank", "3453453455");
User testUser2 = new User("Rossi", "Mario", "mario.rossi@email.it", "rossirossi", "3293293299");

List<User> theseUsers = new List<User> { testUser1, testUser2 };

myLibrary.Users = theseUsers;

#endregion

#region connetto il db

string connectionString = "Data Source=localhost;Initial Catalog=db-library;Integrated Security=True;Encrypt=False";

SqlConnection sqlConnection = new SqlConnection(connectionString);

try
{
    sqlConnection.Open();
    Console.WriteLine("Connesso");

    string checkQuery = "SELECT * FROM books WHERE books.title = 'Libro'";
    string checkQuery2 = "SELECT * FROM books WHERE books.title = 'Altro Libro'";
    string checkQuery3 = "SELECT * FROM books WHERE books.title = 'Ancora un altro Libro'";

    SqlCommand checkCmd = new SqlCommand(checkQuery, sqlConnection);
    SqlCommand checkCmd2 = new SqlCommand(checkQuery2, sqlConnection);
    SqlCommand checkCmd3 = new SqlCommand(checkQuery3, sqlConnection);

    SqlDataReader reader = checkCmd.ExecuteReader();
    bool cond = reader.Read() ? true : false;
    reader.Close();
    SqlDataReader reader2 = checkCmd2.ExecuteReader();
    bool cond2 = reader2.Read() ? true : false;
    reader2.Close();
    SqlDataReader reader3 = checkCmd3.ExecuteReader();
    bool cond3 = reader3.Read() ? true : false;
    reader3.Close();

    if(!cond && !cond2 && !cond3)
    {
        Console.WriteLine("seeding db");
        string booksQuery = "INSERT INTO books (isbn, pages, title, year, genre, shelf_code, author) VALUES ('8891828939', 200, 'Libro', 2020, 'Comico', '7A', 'Maccio Capatonda');" +
                   "INSERT INTO books (isbn, pages, title, year, genre, shelf_code, author) VALUES ('1099887667', 150, 'Altro Libro', 1980, 'Horror', '12B', 'Scrit Tore');" +
                   "INSERT INTO books (isbn, pages, title, year, genre, shelf_code, author) VALUES ('1199887667', 150, 'Ancora un altro Libro', 1981, 'Pesante', '13B', 'Scrit Tore');";

        SqlCommand cmd = new SqlCommand(booksQuery, sqlConnection);
        int affectedRows = cmd.ExecuteNonQuery();
    }

    checkQuery = "SELECT * FROM dvds WHERE dvds.title = 'Film'";
    checkQuery2 = "SELECT * FROM dvds WHERE dvds.title = 'Film Brutto'";

    checkCmd = new SqlCommand(checkQuery, sqlConnection);
    checkCmd2 = new SqlCommand(checkQuery2, sqlConnection);

    reader = checkCmd.ExecuteReader();
    cond = reader.Read() ? true : false;
    reader.Close();
    reader2 = checkCmd2.ExecuteReader();
    cond2 = reader2.Read() ? true : false;
    reader2.Close();

    if(!cond && !cond2)
    {
        Console.WriteLine("seeding dvds");
        string dvdsQuery = "INSERT INTO dvds (serial_number, duration_in_minutes, title, year, genre, shelf_code, author) VALUES ('18891828939', 200, 'Film', 2020, 'Comico', '7A', 'Reg Ista');" +
                   "INSERT INTO dvds (serial_number, duration_in_minutes, title, year, genre, shelf_code, author) VALUES ('11891828939', 200, 'Film Brutto', 2020, 'Horror', '7A', 'Reg Ista');";
        
        SqlCommand cmd = new SqlCommand(dvdsQuery, sqlConnection);
        int affectedRows = cmd.ExecuteNonQuery();
    }

    
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    sqlConnection.Close();
}

#endregion

Console.Write("Inserisci la tua email: ");
string newEmail = Console.ReadLine();

Console.Write("Inserisci la tua password: ");
string newPassword = Console.ReadLine();

Console.WriteLine();

bool registeredUser = false;

User currentUser = new User();

foreach (User user in myLibrary.Users)
{
    if (user.Email == newEmail &&
        user.IsThisPassword(newPassword))
    {
        registeredUser = true;
        currentUser = user;
    }
}

if (!registeredUser)
{
    Console.WriteLine("I dati inseriti non sono presenti nel nostro sistema, devi prima registrarti per poter accedere");
    Console.WriteLine();

    Console.Write("Inserisci il tuo cognome: ");
    string newSurname = Console.ReadLine();

    Console.WriteLine();

    Console.Write("Inserisci il tuo nome: ");
    string newName = Console.ReadLine();

    Console.WriteLine();

    Console.Write("Inserisci una nuova password: ");
    newPassword = Console.ReadLine();

    Console.WriteLine();

    Console.Write("Inserisci il tuo recapito telefonico: ");
    string newPhone = Console.ReadLine();

    Console.WriteLine();

    User newUser = new User(newSurname, newName, newEmail, newPassword, newPhone);

    currentUser = newUser;
}
else
{
    Console.WriteLine($"Bentornato/a {currentUser.Name}");
}



Console.Write("Trova velocemente il prodotto che cerchi (dvd/libro) tramite codice identificativo oppure tramite titolo: ");
string keyWord = Console.ReadLine();

Document searchResult = myLibrary.GetDocument(keyWord);

if (searchResult.Title == "Vouto")
{
    Console.WriteLine("Siamo spiacenti ma attualmente il prodotto richiesto non è presente in nessun scaffale");
}
else
{
    Console.WriteLine($"Abbiamo trovato un prodotto che combacia con i criteri di ricerca: {searchResult.Title}");
    Console.Write("Vuoi procedere con il prestito? ");
    string userAnswer = Console.ReadLine();
    Console.WriteLine();
    if (userAnswer.ToLower() == "si" && searchResult.Available)
    {
        Loan newLoan = new Loan("12", 20092022, 22102022, searchResult, currentUser);
        Console.WriteLine($"Prestito collegato al prodotto {searchResult.Title} accettato!");
    }
    else if (userAnswer.ToLower() == "si" && !searchResult.Available)
    {
        Console.WriteLine($"Il prodotto {searchResult.Title} è già collegato ad un altro prestito");
    }
    else
    {
        Console.WriteLine("Capisco, peccato...");
    }
}