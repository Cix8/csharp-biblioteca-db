public class Dvd : Document
{
    private int durationInMinutes;

    public Dvd(string serialNumber, int durationInMinutes, string title, int year, string genre, string shelfCode, string author) : base(serialNumber, title, year, genre, shelfCode, author)
    {
        this.durationInMinutes = durationInMinutes;
    }
}
