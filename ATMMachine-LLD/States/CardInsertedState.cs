using ATMMachine_LLD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine_LLD.States
{
    public class CardInsertedState : IATMState
    {
        private readonly ATM _atm;

        public CardInsertedState(ATM atm)
        {
            _atm = atm;
        }

        public void EnterPin(string pin)
        {
            if (_atm.CurrentCard.Pin == pin)
            {
                _atm.SetState(_atm.AuthenticatedState);
                Console.WriteLine("PIN verified");
            }
            else
            {
                Console.WriteLine("Invalid PIN");
                _atm.EjectCard();
            }
        }

        public void InsertCard(Card card) => Console.WriteLine("Card already inserted");
        public void Withdraw(decimal amount) => Console.WriteLine("Enter PIN first");
        public void CheckBalance() => Console.WriteLine("Enter PIN first");

        public void EjectCard()
        {
            _atm.CurrentCard = null;
            _atm.SetState(_atm.IdleState);
            Console.WriteLine("Card ejected");
        }
    }
}
