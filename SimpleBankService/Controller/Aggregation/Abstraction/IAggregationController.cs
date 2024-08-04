namespace ConsoleApplication1.Controller.Aggregation.Abstraction
{
    public interface IAggregationController
    {
        void ValidateWithdrawEvent(string id, double amount);
    }
}