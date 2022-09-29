#region Riempio la lista users

User testUser1 = new User("Nat", "Frank", "frank.nat@email.it", "frankfrank", "3453453455");
User testUser2 = new User("Rossi", "Mario", "mario.rossi@email.it", "rossirossi", "3293293299");

List<User> theseUsers = new List<User> { testUser1, testUser2 }

myLibrary.Users = theseUsers;

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