
namespace OOP_LR1;

public class Account(long accountNumber)
{
    
    private long AccountNumber { get; } = accountNumber;
    private readonly List<Card> _listOfCards = new();
    private readonly List<Loan> _listOfLoans = new();

    public void AddCard(Card card)
    {
        _listOfCards.Add(card);
    } 
    
    public Card? FindCard(string cardNumber)
    {
        for (int i = 0; i < _listOfCards.Count; ++i)
        {
            if (_listOfCards[i].GetCardNumber() == cardNumber) return _listOfCards[i];
        }
        return null;
    }

    public void AddLoan(Loan loan, string? cardNumber)
    {
        var card = _listOfCards.Find(p => p.GetCardNumber() == cardNumber);
        if (card is not null) card.PutMoney(loan.GetTotalAmount());
        _listOfLoans.Add(loan);
    }

    public Loan? FindLoan(string? loanId)
    {
        return _listOfLoans.Find(l => l.LoanId == loanId);
    } 

    public void GetInfo()
    {   
        Console.WriteLine($"всего у пользователя {_listOfCards.Count} карт. ");
        for (int i = 0; i < _listOfCards.Count; ++i)
        {
            Console.WriteLine($"карта №{i+1} | номер - {_listOfCards[i].GetCardNumber()} | баланс - {_listOfCards[i].GetMoneyCount()}");
        }
        Console.WriteLine($"всего у пользователя {_listOfLoans.Count} займов");
        for (int i = 0; i < _listOfCards.Count; ++i)
        {
            Console.WriteLine($"займ №{i+1} | номер - {_listOfLoans[i].LoanId} | осталось выплатить - {_listOfLoans[i].GetTotalAmount()}");
        }
    }
    
}