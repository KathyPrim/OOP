using System;

namespace lab7
{
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

        private static long nextNumber = 123;

        public void Populate(decimal balance)
        {
            accNo = NextNumber();
            accBal = balance;
            accType = AccountType.Checking;
        }

        public bool Withdraw(decimal amount)
        {
            bool sufficientFunds = accBal >= amount;
            if (sufficientFunds)
            {
                accBal -= amount;
            }
            return sufficientFunds;
        }

        public decimal Deposit(decimal amount)
        {
            accBal += amount;
            return accBal;
        }

        public long Number()
        {
            return accNo;
        }

        public decimal Balance()
        {
            return accBal;
        }

        public string Type()
        {
            return Convert.ToString(accType);
        }

        private static long NextNumber()
        {
            return nextNumber++;
        }

        public void TransferFrom(ref BankAccount accFrom, decimal amount)
        {
            accFrom.Withdraw(amount);

        }

        public void reverse(ref string s)
        {
            string sRev = "";
            for(int i = s.Length-1; i>-1; i--)
            {
                sRev.Insert(s.Length - i, Convert.ToString(s[i]));
            }
        }
    }
    public class Test
    {
        static void Write(BankAccount toWrite)
        {
            Console.WriteLine("Account number is {0}", toWrite.Number());
            Console.WriteLine("Account balance is {0}", toWrite.Balance());
            Console.WriteLine("Account type is {0}", toWrite.Type());
        }
        /*public static void Main()
        {
            BankAccount b1 = new BankAccount(), b2 = new BankAccount();
            b1.Populate(100);
            b2.Populate(100);
            Console.WriteLine("Account b1");
            Write(b1);
            Console.WriteLine("Account b2");
            Write(b2);
        }*/
    }

}