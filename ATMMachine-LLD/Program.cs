using ATMMachine_LLD.Cash;
using ATMMachine_LLD.Models;
using ATMMachine_LLD;

class Program
{
    static void Main()
    {
        var account = new Account("ACC123", 10000);
        var card = new Card("CARD123", "1234", account);

        var atm = new ATM();
        atm.CashInventory.AddCash(CashDenomination.TwoThousand, 5);
        atm.CashInventory.AddCash(CashDenomination.FiveHundred, 10);

        atm.InsertCard(card);
        atm.EnterPin("1234");
        atm.CheckBalance();
        atm.Withdraw(4500);
        atm.EjectCard();
    }
}
