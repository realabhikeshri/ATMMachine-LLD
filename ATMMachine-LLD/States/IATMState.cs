using ATMMachine_LLD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine_LLD.States
{
    public interface IATMState
    {
        void InsertCard(Card card);
        void EnterPin(string pin);
        void Withdraw(decimal amount);
        void CheckBalance();
        void EjectCard();
    }
}
