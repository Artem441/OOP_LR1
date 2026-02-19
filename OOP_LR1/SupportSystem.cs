namespace OOP_LR1;

public class SupportSystem
{
    public SupportSystem(int clientId, string issueDescription)
    {
        ClientId = clientId;
        IssueDescription = issueDescription;
    }

    private int ClientId { get; }
    private string IssueDescription { get; }
}