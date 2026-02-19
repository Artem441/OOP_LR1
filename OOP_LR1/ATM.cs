using System.Diagnostics.Tracing;

namespace OOP_LR1;

public class ATM
{
    public string AtmAddress { get; }
    private string AtmId { get; set; }
    private long CashAvailable { get; set; }

    //private static List<ATM> _listOfAtms = [];
    
    private string CreateAtmId()
    {
        return HashCode.Combine(AtmAddress).ToString();
    }

    //public static ATM? FindAtm(string address)
    //{
        //return _listOfAtms.FindLast(l => l.AtmAddress == address);
    //}

    public ATM(string atmAddress, long cashAvailable)
    {
        AtmId = CreateAtmId();
        AtmAddress = atmAddress;
        CashAvailable = cashAvailable;
        //_listOfAtms.Add(this);
    }

    private void ReportStatus()
    {
        Console.WriteLine($"Толи денег мало, то ли еще что-то! Ехать сюда -> {AtmAddress}");
    }

    public void DispenseCash(string cardNumber, int amount)
    {
        var card = Card.FindCard(cardNumber);
        if (card is null) return;
        if (card.GetMoneyCount() < amount)
        {
            Console.WriteLine("На карте недостаточно средств!");
        }

        card.WithdrawMoney(amount);
        CashAvailable -= amount;
        if (CashAvailable < 100) ReportStatus();
    }
    public void AcceptCash(string cardNumber, int amount)
    {
        var card = Card.FindCard(cardNumber);
        if (card is null) return;
        card.PutMoney(amount);
        CashAvailable += amount;
        if (CashAvailable < 100) ReportStatus();
    }

    public void GetInfo()
    {
        Console.WriteLine($"Банкомат по адресу {AtmAddress} | наличных в банкомате - {CashAvailable}.");
    }

}