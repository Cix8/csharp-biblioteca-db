public class User
{
    private string surname;
    private string name;
    private string email;
    private string password;
    private string phone;

    public User()
    {

    }
    public User(string surname, string name, string email, string password, string phone)
    {
        this.surname = surname;
        this.name = name;
        this.email = email;
        this.password = "1234" + password + "5678";
        this.phone = phone;
    }

    public string Email
    {
        get
        {
            return this.email;
        }
    }

    public string Surname
    {
        get
        {
            return this.surname;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
    }

    public bool IsThisPassword(string value)
    {
        if (this.password == "1234" + value + "5678")
        {
            return true;
        }
        return false;
    }
}
