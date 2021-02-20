using System;

namespace lab2
{
    enum AccountType
    {
        Credit = 100,
        Deposit = 200,
    }
    struct Account
    {
        public long accNo;
        public decimal accBal;
        public AccountType accType;
    }
    class Program
    {
        static void Main(string[] args)
        {
            AccountType Golden, Platinum;
            Golden = AccountType.Credit;
            Platinum = AccountType.Deposit;
            Console.WriteLine(Golden);
            Console.WriteLine(Platinum);
            Account Me;
            Me.accNo = 1010101010;
            Me.accBal = 100000000000010000;
            Me.accType = AccountType.Deposit;
            Console.WriteLine("Number is {0}, Balance is {1}, Type is {2}", Me.accNo, Me.accBal, Me.accType);
        }
    }
}
