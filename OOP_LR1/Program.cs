using OOP_LR1;

public class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new Bank("Alfa-Bank", "21257654");
        bank.add_branch("Ул. Пушкина дом Колотушкина 23", "5242");
        bank.add_branch("Ул. Скрыганова 12", "3217");
        bank.add_branch("Ул. Семафорова 151", "8219");
        bank.GetInfo();
        bank.Delete_branch("Ул. Пушкина дом Колотушкина 23");
        bank.GetInfo();
        bank.AddEmployee("Данил Колбасенко", "123","СЭО","Ул. Семафорова 151");
        bank.AddEmployee("Виталий Цаль", "437","Менеджер","Ул. Семафорова 151");
        bank.AddEmployee("Иван Лапунов", "007","Безопасник","Ул. Скрыганова 12");
        bank.AddClient("Арсений Мялик", "+375 44 992 5305", "MC4285665");
        bank.AddClient("Фил Филыч", "+375 44 132 9856", "MC4229689");
        bank.AddClient("Иван Иваныч", "+375 67 786 4219", "MP3727619");
        var cardNumber1 = bank.FindClient("+375 44 992 5305")?.CreateCard();
        var cvv1 = bank.FindClient("+375 44 992 5305")?.GetAccount().FindCard(cardNumber1).GetCvv();
        bank.FindClient("+375 44 992 5305")?.GetAccount().FindCard(cardNumber1).PutMoney(1000);
        bank.FindClient("+375 44 992 5305")?.GetAccount().FindCard(cardNumber1).PutMoney(2250);
        bank.FindClient("+375 44 992 5305")?.GetAccount().FindCard(cardNumber1).WithdrawMoney(1750);
        bank.FindClient("+375 44 992 5305")?.GetAccount().FindCard(cardNumber1).BlockCard();
        bank.FindClient("+375 44 992 5305")?.GetAccount().FindCard(cardNumber1).PutMoney(1000);
        bank.FindClient("+375 44 992 5305")?.GetAccount().FindCard(cardNumber1).UnblockCard();
        var cardNumber2 = bank.FindClient("+375 44 132 9856")?.CreateCard();
        bank.FindClient("+375 44 132 9856")?.GetAccount().FindCard(cardNumber2).PutMoney(600);
        bank.FindClient("+375 44 992 5305")?.GetAccount().FindCard(cardNumber1).GetMoneyCount();
        if (cardNumber2 != null && cardNumber1 != null)
            bank.FindClient("+375 44 992 5305")?.SendMoney(cardNumber1, cardNumber2, 725, cvv1);
        bank.FindClient("+375 44 992 5305")?.GetAccount().FindCard(cardNumber1).GetMoneyCount();
        bank.FindClient("+375 44 132 9856")?.GetAccount().FindCard(cardNumber2).GetMoneyCount();
        string? loanId1 = bank.FindClient("+375 44 132 9856")?.GetLoan(cardNumber2,3500);
        bank.FindClient("+375 44 132 9856")?.GetInfo();
        bank.FindClient("+375 44 132 9856")?.PayForLoan(loanId1,cardNumber2, 2000);
        bank.FindClient("+375 44 132 9856")?.GetInfo();
        bank.AddAtm("Ул. Шишкина 13", 50000);
        bank.AtmOperation("Ул. Шишкина 13",2,cardNumber2,825);
        bank.AtmOperation("Ул. Шишкина 13",1,cardNumber2,825);
        bank.FindClient("+375 44 992 5305")?.SupportSystemMessage("Сначала денег было много, сейсчас мало, разберитесь");

    }
}