using System;
using ConsoleApplication1.Assert.Database;
using ConsoleApplication1.Controller.Account.Abstraction;
using EventSourcingImplementation.Assert.Database;

namespace ConsoleApplication1.Controller.Account
{
    public class BasicAccountController : IAccountController
    {
        private readonly AccountDbManager _accountDbManager;
        
        public BasicAccountController()
        {
            _accountDbManager = new AccountDbManager();
        }
        
        public void CreateAccount(string id, DateTime createAt, DateTime updateAt)
        {
            _accountDbManager.Add(id, 0, createAt, updateAt);
        }

        public void Deposit(string id, double amount)
        {
            _accountDbManager.Update(id, GetAccount(id).Balance + amount);
        } 
        
        public void Withdraw(string id, double amount)
        {
            _accountDbManager.Update(id, GetAccount(id).Balance - amount);
        }
        public Model.Account.Account GetAccount(string id)
        {
            return _accountDbManager.Get(id);
        }
    }
}