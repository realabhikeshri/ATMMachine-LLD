using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine_LLD.Models
{
    public class Account
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance < amount) return false;
            Balance -= amount;
            return true;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}
