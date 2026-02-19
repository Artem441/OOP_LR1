namespace OOP_LR1;

public class Employee(string fullName, string employeeId, string position)
{
    private string EmployeeId { get; } = employeeId;
    public string FullName { get; } = fullName;
    private string Position { get; set; } = position;

    public void ChangePosition(string newPosition)
    {
        Position = newPosition;
    }

    public void GetInfo()
    {
        Console.WriteLine($"{FullName} | id: {EmployeeId} | Должность - {Position}");
        
    }
}