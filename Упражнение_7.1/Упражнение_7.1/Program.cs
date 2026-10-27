using System;

namespace BankAccountApp
{
    // Перечислимый тип для вида банковского счета
    public enum AccountType
    {
        Current,    // Текущий
        Savings,    // Сберегательный
        Deposit     // Депозитный
    }

    // Класс "Счет в банке"
    public class BankAccount
    {
        // Закрытые поля 
        private string accountNumber;
        private double balance;
        private AccountType type;

        // Метод для заполнения данных
        public void SetAccountData(string number, double initialBalance, AccountType accountType)
        {
            accountNumber = number;
            balance = initialBalance;
            type = accountType;
        }

        // Методы для чтения данных
        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public double GetBalance()
        {
            return balance;
        }

        public AccountType GetAccountType()
        {
            return type;
        }

        // Метод для вывода информации об объекте на печать
        public void PrintInfo()
        {
            Console.WriteLine("Информация о банковском счете:");
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance:C}");
            Console.WriteLine($"Тип счета: {type}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта класса
            BankAccount myAccount = new BankAccount();

            // Заполнение полей объекта через метод доступа
            myAccount.SetAccountData("40817810500001234567", 150500.75, AccountType.Savings);

            // Вывод информации об объекте на печать
            myAccount.PrintInfo();

            // Пример поштучного чтения полей с помощью Get-методов
            Console.WriteLine($"\nПроверка отдельного чтения баланса: {myAccount.GetBalance():C}");

            Console.ReadKey();
        }
    }
}

