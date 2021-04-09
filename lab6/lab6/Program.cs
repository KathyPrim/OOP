using System;

enum AccountType
{
    Checking,
    Deposit
}

class BankAccount
{
    private long accNo;
    private decimal accBal;
    private AccountType accType;
    private static long next = 123;

    public void Populate(decimal Bal)
    {
        accNo = nextNum();
        accBal = Bal;
        accType = AccountType.Checking;
    }

    public long num() { return accNo; }
    public decimal bal() { return accBal; }
    public AccountType Atype() { return accType; }
    private long nextNum() { return next++; }
    public decimal deposit(decimal sum) { return accBal + sum; }
    public bool withdraw(decimal amount)
    {
        return (accBal > amount);
    }
}

class CreateAccount
{
    static void Main()
    {
        BankAccount berts = NewBankAccount();
        Write(berts);

        /*BankAccount freds = NewBankAccount();
        Write(freds);*/

        TestDeposit(berts);
        Write(berts);
    }

    public static void TestDeposit(BankAccount Acc)
    {
        Console.Write("Enter the amount of deposit: ");
        decimal sum = decimal.Parse(Console.ReadLine());
        Acc.deposit(sum);
    }

    static BankAccount NewBankAccount()
    {
        BankAccount created = new BankAccount();
        /*Console.Write("Enter the account number   : ");
        long number = long.Parse(Console.ReadLine());*/

        Console.Write("Enter the account balance! : ");
        decimal balance = decimal.Parse(Console.ReadLine());

        //long number = created.nextNum();

        created.Populate(balance);

        /*created.accNo = number;
        created.accBal = balance;
        created.accType = AccountType.Checking;*/

        return created;
    }

    static void Write(BankAccount toWrite)
    {
        Console.WriteLine("Account number is {0}", toWrite.num());
        Console.WriteLine("Account balance is {0}", toWrite.bal());
        Console.WriteLine("Account type is {0}", toWrite.Atype());
    }
}
