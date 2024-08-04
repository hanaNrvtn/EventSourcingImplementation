using System;

namespace ConsoleApplication1.Model.Account
{
    public class Account
    {
        public Account(string id, double balance, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Balance = balance;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public string Id { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAt { get; }  // add to data base
        DateTime UpdatedAt { get; set; }
    }
}