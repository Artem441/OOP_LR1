namespace OOP_LR1;

public class Client
{
    private string FullName { get; }
    public string TelephoneNumber { get; private set; }
    private string PassportData { get; }
    public int ClientId { get; }

    private Account account { get; }
    private readonly List<string> _cards = [];
    private static long _accountsCount = 0; // for number of Accounts 

    public Client(string fullName, string telephoneNumber, string passportData)
    {
        _accountsCount++;
        FullName = fullName;
        TelephoneNumber = telephoneNumber;
        PassportData = passportData;
        ClientId = Math.Abs(HashCode.Combine(fullName, passportData));
        account = new Account(_accountsCount);
        Console.WriteLine($"Добавлен клиент {fullName} его id: {ClientId}");
    }
    
    public string CreateCard()
    {
        Console.Write($"Для пользователя {FullName} ");
        Card card = new Card(out var cardNumber);
        account.AddCard(card);
        _cards.Add(cardNumber);
        return cardNumber;
    }
    

    public string? GetLoan(string? card, long amount)
    {
        Loan loan = new Loan(ClientId, amount, out var id);
        account.AddLoan(loan,card);
        return id;
    }

    public void PayForLoan(string? loanId,string? card, long amount)
    {
        account.FindLoan(loanId)?.MakePayment(amount);
    }

    public bool SendMoney(string senderCardNumber, string recivierCardNumber, int amount, int? senderCardCvv)
    {
        Card? card = account.FindCard(senderCardNumber);
        if (card == null)
        {
            return false;
        }

        Transaction transaction = new Transaction(card, recivierCardNumber, amount, senderCardCvv);
        transaction.ExecuteOperation();

        return true;
    }
    
    public void SupportSystemMessage(string infoAboutProblem)
    {
        SupportSystem supportSystem = new SupportSystem(ClientId, infoAboutProblem);
        Console.WriteLine($"Пользователем {FullName} была отправлена жалоба ,ее содержание:\n{infoAboutProblem}");
    }

    public Account GetAccount()
    {
        return account;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Это аккаунт пользователя {FullName}");
        Console.WriteLine($"Номер телефона - {TelephoneNumber}");
        Console.WriteLine($"ID - {ClientId}");
        Console.WriteLine(
            "----------------------------------------Отчёт по аккаунту----------------------------------------");
        account.GetInfo();
    }
}