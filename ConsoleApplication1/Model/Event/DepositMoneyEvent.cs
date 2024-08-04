using Newtonsoft.Json;

namespace ConsoleApplication1.Model.Event
{
    public class DepositMoneyEvent
    {
        public DepositMoneyEvent(string id, string accountId, string type, string properties)
        {
            AccountId = accountId;
            Id = id;
            Type = type;
            Properties = JsonConvert.SerializeObject(this);
        }

        public string Id { get; }
        public string AccountId { get; }
        public string Type { get; set; }
        public string Properties { get; set; }
    }
}