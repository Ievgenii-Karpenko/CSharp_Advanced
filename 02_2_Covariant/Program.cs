using System;
using System.Collections.Generic;

namespace Covariant
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
    interface IBank<out T>
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
            IBank<DepositAccount> depositBank = new Bank<DepositAccount>();
            Account acc1 = depositBank.CreateAccount(34);

            //       T                                  T : Account
            IBank<Account> ordinaryBank = new Bank<DepositAccount>();
            // or
            // IBank<Account> ordinaryBank = depositBank;
            Account acc2 = ordinaryBank.CreateAccount(70);

            Console.Read();
        }
    }
    
}

namespace Contrvariant
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

    interface ITransaction<in T>
    {
        void DoOperation(T account, int sum);
    }

    class Transaction<T> : ITransaction<T> where T : Account
    {
        public void DoOperation(T account, int sum)
        {
            account.DoTransfer(sum);
        }
    }

    class A
    {

    }

    class B : A
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            IList<A> list1 = new List<A>();
            list1.Add(new A());
            list1.Add(new B());


            ITransaction<Account> accTransaction = new Transaction<Account>();
            accTransaction.DoOperation(new Account(), 400);

            ITransaction<DepositAccount> depAccTransaction = new Transaction<Account>();
            depAccTransaction.DoOperation(new DepositAccount(), 450);

            Console.Read();
        }
    }

}