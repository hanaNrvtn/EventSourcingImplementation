using System;
using ConsoleApplication1.Assert.Database;
using ConsoleApplication1.Model.Event;

namespace ConsoleApplication1.Controller.Projector
{
    public class Projector
    {
        private readonly AccountDbManager _accountDbManager;

        public Projector(AccountDbManager accountDbManager)
        {
            _accountDbManager = accountDbManager;
        }

        public void OnAccountCreated(CreateAccountEvent createAccountEvent)
        {
            _accountDbManager.Add(createAccountEvent.AccountId,0, DateTime.Now, DateTime.Now);
        }
        
        public void OnDeposit(DepositMoneyEvent depositMoneyEvent, double amount)
        { 
            _accountDbManager.Update(depositMoneyEvent.AccountId, _accountDbManager.Get(depositMoneyEvent.AccountId).Balance + amount);
        }
        
        public void OnWithdraw(WithdrawMoneyEvent withdrawMoneyEvent, double amount)
        {
            _accountDbManager.Update(withdrawMoneyEvent.AccountId, _accountDbManager.Get(withdrawMoneyEvent.AccountId).Balance - amount);
        }
    }
}