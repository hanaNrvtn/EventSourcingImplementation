namespace EventSourcingImplementation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // basic implementation
            var id = Guid.NewGuid().ToString();
            var basicAccountController = new BasicAccountController();
            basicAccountController.CreateAccount(id, DateTime.Now, DateTime.Now);
            basicAccountController.Deposit(id, 1000);
            basicAccountController.Withdraw(id, 1000);

            var id2 = Guid.NewGuid().ToString();
            basicAccountController.CreateAccount(id2, DateTime.Now, DateTime.Now);

            // adding projector
            var id3 = Guid.NewGuid().ToString();
            var improvedAccountController = new ImprovesAccountController();
            improvedAccountController.CreateAccount(id3, DateTime.Now, DateTime.Now);
            improvedAccountController.Deposit(id3, 1000);
            improvedAccountController.Withdraw(id3, 950);
            
            // adding aggregation
            var moreImprovedAccountController = new MoreImprovedAccountController();
            moreImprovedAccountController.Withdraw(id3, 1000000);
            moreImprovedAccountController.Deposit(id3, 10000000); 
        }
    }
}