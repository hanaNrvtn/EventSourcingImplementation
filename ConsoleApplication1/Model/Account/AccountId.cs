using System;

namespace ConsoleApplication1.Model.Account
{
    public class AccountId
    {
        public string GetId()
        {
            return Guid.NewGuid().ToString();
        }

    }
}