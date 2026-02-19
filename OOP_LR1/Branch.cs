namespace OOP_LR1;

public class Branch(string address, string branchId)
{
    public string Address { get; } = address;
    public string BranchId { get; } = branchId;
    private readonly List<Employee> Employees = [];

    // let branches work with same timetable
    public static void Open_branches()
    {
        Console.WriteLine("Отделение открыто");
    }

    public static void Close_branches()
    {
        Console.WriteLine("Отделение закрыто");
    }
    public void AddEmployee(string fullName, string employeeId, string position)
    {
        Employee employee = new Employee(fullName, employeeId, position);
        Console.WriteLine($"Добавлен сотрудник {fullName}. На должность {position}.");
        Employees.Add(employee);
    }

    public void RemoveEmployee(Employee employee)
    {
        if (Employees.Any(p => p.FullName == employee.FullName))
        {
            Console.WriteLine($"Уволен сотрудник {employee.FullName}.");
            Employees.Remove(employee);
        }
    }
    
}