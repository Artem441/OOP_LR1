using System.Runtime.InteropServices.JavaScript;
using System.Text;

namespace OOP_LR1;

public class Card
{
    private string CardNumber { get; }
    private long Balance { get; set; } = 0;
    private readonly int _cvv;
    private static List<Card> _allExisitingCard = new();
    public bool IsBlocked { get; private set; } = false;

    public Card(out string cardNumber)
    {
        CardNumber = GenerateRandomCardNumber();
        _cvv = GenerateCvv();
        _allExisitingCard.Add(this);
        Console.WriteLine($"была создана карта с номером {CardNumber} и CVV {_cvv}");
        cardNumber = CardNumber;
    }
    
    public static Card? FindCard(string cardNumber)
    {
        try
        {
            return _allExisitingCard.Find(c => c.CardNumber == cardNumber) ?? throw new InvalidOperationException();
        }
        catch (Exception e)
        {
            Console.WriteLine("Нет такой карты");
        }

        return null;
    }
    
    private int GenerateCvv()
    {
        Random random = new();
        return random.Next(100, 999);
    }
    private string GenerateRandomCardNumber()
    {
        Random random = new Random();
        StringBuilder sb = new StringBuilder(16);
        for (int i = 0; i < 16; ++i)
        {
            sb.Append(random.Next(0, 9));
        }

        return sb.ToString();
    }

    public void PutMoney(long sum)
    {
        if (IsBlocked)
        {
            Console.WriteLine("карта заблокирована");
            return;
        }
        Balance += sum;
        Console.WriteLine($"На карту {CardNumber} зачислено {sum} руб.");
        Console.WriteLine($"Текущий баланс карты {Balance}");
    }

    public long GetMoneyCount()
    {
        long count = Balance;
        Console.WriteLine($"Сейчас на карте {CardNumber} {count} руб.");
        return count;
    }

    public bool WithdrawMoney(int sum)
    {
        if (IsBlocked == true || sum > Balance) return false;
        Balance -= sum;
        Console.WriteLine($"С карты {CardNumber} снято {sum} руб.");
        Console.WriteLine($"Сейчас на карте {CardNumber} {Balance} руб.");
        return true;
    }

    public void BlockCard()
    {
        if (IsBlocked)
        {
            Console.WriteLine("Карта уже заблокирована.");
            return;
        }

        IsBlocked = true;
        Console.WriteLine($"Карта {CardNumber} заблокирована.");
    }
    public void UnblockCard()
    {
        if (!IsBlocked)
        {
            Console.WriteLine("Карта не заблокирована.");
            return;
        }

        IsBlocked = false;
        Console.WriteLine($"Карта {CardNumber} разблокирована.");
    }

    public int? GetCvv()
    {
        return _cvv;
    }
    public string GetCardNumber()
    {
        return CardNumber;
    }
}