namespace OOP_LR1;

public class Bank(string name, string licenseNumber)
{
    private string Name { get; } = name;
    private int BranchCount { get; set; } = 0;
    private string LicenseNumber { get; } = licenseNumber;

    private readonly List<Branch> _allBranches = [];
    private readonly List<ATM> _atms = [];
    private readonly List<Client> _allClients = [];

    public void add_branch(string address, string branchId)
    {
        if (_allBranches.Any(b => address == b.Address))
        {
            return; // if already exist
        }

        BranchCount++;
        _allBranches.Add(new Branch(address, branchId));
    }

    public void AddEmployee(string fullName, string employeeId, string position, string fullAddress)
    {
        Branch? branch = _allBranches.Find(b => b.Address == fullAddress);
        if (branch is null) return;
        branch.AddEmployee(fullName, employeeId, position);
    }
    public void Delete_branch(string address)
    {
        Branch? branch = _allBranches.Find(p => p.Address == address);
        if (branch is null) return;
        _allBranches.Remove(branch);
        BranchCount--;
    }
    public void AddAtm(string address, long cashCount)
    {
        _atms.Add(new ATM(address, cashCount));
        Console.WriteLine($"Создан банкомат по адресу {address}");
    }

    // 1-put money; 2-get money
    public void AtmOperation(string address, int operationCode, string cardNumber, int amout)
    {
        ATM? atm = null;
        for (int i = 0; i < _atms.Count; ++i)
        {
            if (_atms[i].AtmAddress == address) atm = _atms[i];
        }

        if (atm == null) return;
        switch (operationCode)
        {
            case 1:
                atm.AcceptCash(cardNumber, amout);
                break;
            case 2:
                atm.DispenseCash(cardNumber, amout);
                break;
            default:
                Console.WriteLine("Нету такой операции в банкомате");
                return;
        }
    }

    public void GetInfo()
    {
        Console.WriteLine($"Банк '{Name}' |Номер Лицензии - {LicenseNumber} | Отделений - {BranchCount}");
        for (int i = 0; i < _allBranches.Count; ++i)
        {
            Console.WriteLine($"Отделение №{i+1} | адрес {_allBranches[i].Address} | номер лицензии {_allBranches[i].BranchId}");
        }
    }

    public Client? FindClient(string telephoneNumber)
    {
        Client? client = _allClients.Find(c => c.TelephoneNumber == telephoneNumber);
        if (client is null) return null;
        return client;
    }

    public void AddClient(string fullName, string telephoneNumber, string passportData)
    {
        _allClients.Add(new Client(fullName, telephoneNumber, passportData));
    }
}