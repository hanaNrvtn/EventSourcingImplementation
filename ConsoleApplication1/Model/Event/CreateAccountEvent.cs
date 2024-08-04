using System;
using Newtonsoft.Json;

namespace ConsoleApplication1.Model.Event
{
    public class CreateAccountEvent
    {
        public CreateAccountEvent(string id, string accountId, string type, string properties)
        {
            Id = id;
            AccountId = accountId;
            Type = type;
            Properties = JsonConvert.SerializeObject(this);
        }

        public string Id { get; }
        public string AccountId { get; }
        public string Type { get; set; }
        public string Properties { get; set; }
    }
}