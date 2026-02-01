using ATMMachine_LLD.Cash;
using ATMMachine_LLD.Models;
using ATMMachine_LLD.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine_LLD
{
    public class ATM
    {
        public Card CurrentCard { get; set; }
        public CashInventory CashInventory { get; } = new();

        public IATMState IdleState { get; }
        public IATMState CardInsertedState { get; }
        public IATMState AuthenticatedState { get; }

        private IATMState _currentState;

        public ATM()
        {
            IdleState = new IdleState(this);
            CardInsertedState = new CardInsertedState(this);
            AuthenticatedState = new AuthenticatedState(this);
            _currentState = IdleState;
        }

        public void SetState(IATMState state) => _currentState = state;

        public void InsertCard(Card card) => _currentState.InsertCard(card);
        public void EnterPin(string pin) => _currentState.EnterPin(pin);
        public void Withdraw(decimal amount) => _currentState.Withdraw(amount);
        public void CheckBalance() => _currentState.CheckBalance();
        public void EjectCard() => _currentState.EjectCard();
    }
}
