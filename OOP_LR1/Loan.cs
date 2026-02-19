namespace OOP_LR1;

public class Loan
{
    public string? LoanId { get; private set; }

    private int ClientId { get; }
    private long TotalAmount { get; set; }

    public Loan(int clientId, long amount, out string? id)
    {
        ClientId = clientId;
        TotalAmount = amount;
        LoanId = CreateLoanId();
        id = LoanId;
    }

    public long MakePayment(long amount)
    {
        if (amount > TotalAmount)
        {
            amount -= TotalAmount;
            TotalAmount = 0;
            Console.WriteLine("Кредит полностью погашён");
            return amount;
        }

        TotalAmount -= amount;
        return 0;
    }

    public long GetTotalAmount()
    {
        return TotalAmount;
    }

    private string? CreateLoanId()
    {
        return HashCode.Combine(ClientId, TotalAmount).ToString();
    }
    
}