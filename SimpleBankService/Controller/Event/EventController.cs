using System;
using ConsoleApplication1.Assert.Database;
using ConsoleApplication1.Controller.Event.Abstraction;
using ConsoleApplication1.Model.Event;
using EventSourcingImplementation.Assert.Database;

namespace ConsoleApplication1.Controller.Event
{
    public class EventController : IEventController
    {
        private readonly EventDbManager _eventDbManager;
        private readonly Projector.Projector _projector;

        public EventController()
        {
            _eventDbManager = new EventDbManager();
            _projector = new Projector.Projector(new AccountDbManager());
        }

        public void AddCreateAccountEvent(CreateAccountEvent createAccountEvent)
        {
            _eventDbManager.AddEvent(createAccountEvent.Id, createAccountEvent.AccountId,
                createAccountEvent.Type, createAccountEvent.Properties);

            _projector.OnAccountCreated(createAccountEvent);
        } 
        public void AddDepositMoneyEvent(DepositMoneyEvent depositMoneyEvent, double amount) // better to be combined with event
        {
            _eventDbManager.AddEvent(depositMoneyEvent.Id, depositMoneyEvent.AccountId,
                depositMoneyEvent.Type, depositMoneyEvent.Properties);

            _projector.OnDeposit(depositMoneyEvent, amount);
        } 
        public void AddWithdrawMoneyEvent(WithdrawMoneyEvent withdrawMoneyEvent, double amount)
        {
            _eventDbManager.AddEvent(withdrawMoneyEvent.Id, withdrawMoneyEvent.AccountId,
                withdrawMoneyEvent.Type, withdrawMoneyEvent.Properties);

            _projector.OnWithdraw(withdrawMoneyEvent, amount);
        } 
        public void AddHitWithdrawLimitEvent(HitWithdrawLimit hitWithdrawLimit)
        {
            _eventDbManager.AddEvent(hitWithdrawLimit.Id, hitWithdrawLimit.AccountId,
                hitWithdrawLimit.Type, hitWithdrawLimit.Properties);
        } 
        public void AddHitDepositLimitEvent(HitDepositLimit hitDepositLimit)
        {
            _eventDbManager.AddEvent(hitDepositLimit.Id, hitDepositLimit.AccountId,
                hitDepositLimit.Type, hitDepositLimit.Properties);
        } 
    }
}