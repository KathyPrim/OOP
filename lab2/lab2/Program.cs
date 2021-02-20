using System;

namespace lab2
{
    enum AccountType
    {
        Credit,
        Deposit,
    }
    struct Account
    {
        public long accNu;
        public decimal accBal;
        public AccountType accType;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AccountType Golden, Platinum;
            Golden = AccountType.Credit;
            Platinum = AccountType.Deposit;
            Console.WriteLine(Golden);
            Console.WriteLine(Platinum);
            Account Me;
            Me.accNu = 1010101010;
            Me.accBal = 100000000000010000;
            Me.accType = AccountType.Deposit;
        }
    }
}
