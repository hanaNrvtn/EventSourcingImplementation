using System;
using ConsoleApplication1.Assert.Database;
using ConsoleApplication1.Controller.Aggregation.Abstraction;
using ConsoleApplication1.Controller.Event;
using ConsoleApplication1.Model.Event;

namespace ConsoleApplication1.Controller.Aggregation
{
    public class AggregationController : IAggregationController
    {
        private readonly EventController _eventController;
        private readonly AccountDbManager _accountDbManager;
        public AggregationController()
        {
            _accountDbManager = new AccountDbManager();
            _eventController = new EventController();
        }

        public void ValidateWithdrawEvent(string id, double amount)
        {
            var balance = _accountDbManager.Get(id).Balance;
            
            if (balance < amount)
                _eventController.AddHitWithdrawLimitEvent(new HitWithdrawLimit(Guid.NewGuid().ToString(), id, "withdrawHitLimit", "dkfl"));
            else        
                _eventController.AddWithdrawMoneyEvent(new WithdrawMoneyEvent(Guid.NewGuid().ToString(), id, "withdraw event", "dfkjdkfj"), amount);
        }
        
        public void ValidateDepositEvent(string id, double amount)
        {
            var balance = _accountDbManager.Get(id).Balance;
            
            if (balance < 1000 && amount > 1000000)
                _eventController.AddHitDepositLimitEvent(new HitDepositLimit(Guid.NewGuid().ToString(), id, "withdrawHitLimit", "dkfl"));
            else
                _eventController.AddDepositMoneyEvent(new DepositMoneyEvent(Guid.NewGuid().ToString(), id, "withdraw event", "dfkjdkfj"), amount);
        }
    }
}