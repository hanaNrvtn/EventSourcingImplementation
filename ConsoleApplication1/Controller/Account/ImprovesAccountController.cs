using System;
using ConsoleApplication1.Assert.Database;
using ConsoleApplication1.Controller.Account.Abstraction;
using ConsoleApplication1.Controller.Event;
using ConsoleApplication1.Model.Event;

namespace ConsoleApplication1.Controller.Account
{
    public class ImprovesAccountController : IAccountController
    {
        private readonly EventController _eventController;
        private readonly AccountDbManager _accountDbManager;

        public ImprovesAccountController()
        {
            _accountDbManager = new AccountDbManager();
            _eventController = new EventController();
        }
        
        public void CreateAccount(string id, DateTime createAt, DateTime updateAt)
        {
            _eventController.AddCreateAccountEvent(new CreateAccountEvent(Guid.NewGuid().ToString(), id, "create account", "dkfjdkf"));   
        }

        public void Deposit(string id, double amount)
        {
            _eventController.AddDepositMoneyEvent(new DepositMoneyEvent(Guid.NewGuid().ToString(), id, "deposite money", "djkfjdkfj"), amount);
        } 
        public void Withdraw(string id, double amount)
        {
            _eventController.AddWithdrawMoneyEvent(new WithdrawMoneyEvent(Guid.NewGuid().ToString(), id, "withdraw event", "dfkjdkfj"), amount);
        }

        public Model.Account.Account GetAccount(string id)
        {
            return _accountDbManager.Get(id);
        }
    }
}