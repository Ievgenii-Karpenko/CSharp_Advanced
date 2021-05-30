using System;

namespace ConsoleApplication1
{
    class Account
    {
        public virtual void DoTransfer(int sum)
        {
            Console.WriteLine($"Клиент положил на счет {sum} $");
        }
    }
    class DepositAccount : Account
    {
        public override void DoTransfer(int sum)
        {
            Console.WriteLine($"Клиент положил на депозитный счет {sum} $");
        }
    }

    //Covariant/contrvariant/invariant interface
    interface IBank<in T>
    {
        T CreateAccount(int sum);
    }

    class Bank<T> : IBank<T> where T : Account, new()
    {
        public T CreateAccount(int sum)
        {
            T acc = new T();  // create account
            acc.DoTransfer(sum);
            return acc;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            IBank<DepositAccount> depositBank = new Bank<Account>();
            Account acc1 = depositBank.CreateAccount(25);

            //       T                                  T : Account
            IBank<Account> ordinaryBank = new Bank<DepositAccount>();
            // or
            // IBank<Account> ordinaryBank = depositBank;
            Account acc2 = ordinaryBank.CreateAccount(70);

            Console.Read();
        }
    }
    
}