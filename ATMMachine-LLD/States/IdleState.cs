using ATMMachine_LLD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine_LLD.States
{
    public class IdleState : IATMState
    {
        private readonly ATM _atm;

        public IdleState(ATM atm)
        {
            _atm = atm;
        }

        public void InsertCard(Card card)
        {
            _atm.CurrentCard = card;
            _atm.SetState(_atm.CardInsertedState);
            Console.WriteLine("Card inserted");
        }

        public void EnterPin(string pin) => Console.WriteLine("Insert card first");
        public void Withdraw(decimal amount) => Console.WriteLine("Insert card first");
        public void CheckBalance() => Console.WriteLine("Insert card first");
        public void EjectCard() => Console.WriteLine("No card to eject");
    }
}
