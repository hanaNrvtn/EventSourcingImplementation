using System;
using ConsoleApplication1.Controller.Account.Abstraction;
using ConsoleApplication1.Controller.Aggregation;
using ConsoleApplication1.Model.Event;

namespace ConsoleApplication1.Controller.Account
{
    public class MoreImprovedAccountController : IAccountController
    {
        private readonly AggregationController _aggregationController;

        public MoreImprovedAccountController()
        {
            _aggregationController = new AggregationController();
        }

        public void CreateAccount(string id, DateTime createAt, DateTime updateAt)
        {
            // to be implemeted
        }

        public void Deposit(string id, double amount)
        {
            _aggregationController.ValidateDepositEvent(id, amount);
        }

        public void Withdraw(string id, double amount)
        {
            _aggregationController.ValidateWithdrawEvent(id, amount);
        }

        public Model.Account.Account GetAccount(string id)
        {
            throw new NotImplementedException();
        }
    }
}