public class Loan
{
    private string idCode;
    private int startDate;
    private int endDate;
    private Document document;
    private User user;

    public Loan(string idCode, int startDate, int endDate, Document document, User user)
    {
        this.idCode = idCode;
        this.startDate = startDate;
        this.endDate = endDate;
        this.document = document;
        this.user = user;
    }
}
