using ConsoleApplication1.Model.Event;

namespace ConsoleApplication1.Controller.Event.Abstraction
{
    public interface IEventController
    {
        void AddCreateAccountEvent(CreateAccountEvent createAccountEvent);
        void AddDepositMoneyEvent(DepositMoneyEvent depositMoneyEvent, double amount);
        void AddWithdrawMoneyEvent(WithdrawMoneyEvent withdrawMoneyEvent, double amount);
    }
}