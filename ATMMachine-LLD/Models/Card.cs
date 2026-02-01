using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine_LLD.Models
{
    public class Card
    {
        public string CardNumber { get; }
        public string Pin { get; }
        public Account LinkedAccount { get; }

        public Card(string cardNumber, string pin, Account account)
        {
            CardNumber = cardNumber;
            Pin = pin;
            LinkedAccount = account;
        }
    }
}
