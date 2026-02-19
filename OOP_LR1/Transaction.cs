namespace OOP_LR1;

public class Transaction(Card senderCard, string receiverNumberCard, int amount, int? cvv)
{
    private Card SenderCard { get; set; } = senderCard;
    private string ReceiverNumberCard { get; set; } = receiverNumberCard;
    private int Amount { get; set; } = amount;

    public bool ExecuteOperation()
    {
        if (cvv != SenderCard.GetCvv())
        {
            Console.WriteLine("Неверный Cvv код, транзакция отклонена");
            return false;
        }

        if (!SenderCard.WithdrawMoney(Amount)) return false;
        Card? card = Card.FindCard(ReceiverNumberCard);
        if (card == null)
        {
            Console.WriteLine("Транзакция отклонена");
            return false;
        }
        //SenderCard.WithdrawMoney(Amount);
        card.PutMoney(Amount);
        Console.WriteLine($"Транзакция перевода выполнена выполнена успешно");
        return true;
    }
}