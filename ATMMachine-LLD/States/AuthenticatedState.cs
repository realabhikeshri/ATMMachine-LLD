using ATMMachine_LLD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine_LLD.States
{
    public class AuthenticatedState : IATMState
    {
        private readonly ATM _atm;

        public AuthenticatedState(ATM atm)
        {
            _atm = atm;
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Balance: {_atm.CurrentCard.LinkedAccount.Balance}");
        }

        public void Withdraw(decimal amount)
        {
            var account = _atm.CurrentCard.LinkedAccount;

            if (!account.Withdraw(amount))
            {
                Console.WriteLine("Insufficient account balance");
                return;
            }

            if (!_atm.CashInventory.CanDispense(amount))
            {
                Console.WriteLine("ATM has insufficient cash");
                account.Deposit(amount);
                return;
            }

            var notes = _atm.CashInventory.Dispense(amount);
            Console.WriteLine("Cash dispensed:");
            foreach (var n in notes)
                Console.WriteLine($"{n.Key} x {n.Value}");
        }

        public void EjectCard()
        {
            _atm.CurrentCard = null;
            _atm.SetState(_atm.IdleState);
            Console.WriteLine("Card ejected");
        }

        public void InsertCard(Card card) => Console.WriteLine("Transaction in progress");
        public void EnterPin(string pin) => Console.WriteLine("Already authenticated");
    }
}
