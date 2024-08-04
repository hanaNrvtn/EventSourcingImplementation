using System;

namespace ConsoleApplication1.Controller.Account.Abstraction
{
    public interface IAccountController
    {
        void CreateAccount(string id, DateTime createAt, DateTime updateAt);
        void Deposit(string id, double amount);
        void Withdraw(string id, double amount);
        Model.Account.Account GetAccount(string id);
    }
}
