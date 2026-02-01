using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine_LLD.Cash
{
    public class CashInventory
    {
        private readonly Dictionary<CashDenomination, int> _cash = new();

        public void AddCash(CashDenomination denom, int count)
        {
            _cash[denom] = _cash.GetValueOrDefault(denom) + count;
        }

        public bool CanDispense(decimal amount)
        {
            return GetDispenseNotes(amount) != null;
        }

        public Dictionary<CashDenomination, int> Dispense(decimal amount)
        {
            var notes = GetDispenseNotes(amount);
            if (notes == null) throw new Exception("Insufficient ATM cash");

            foreach (var kv in notes)
                _cash[kv.Key] -= kv.Value;

            return notes;
        }

        private Dictionary<CashDenomination, int> GetDispenseNotes(decimal amount)
        {
            var result = new Dictionary<CashDenomination, int>();
            int remaining = (int)amount;

            foreach (var denom in Enum.GetValues(typeof(CashDenomination))
                                      .Cast<CashDenomination>()
                                      .OrderByDescending(d => (int)d))
            {
                if (!_cash.ContainsKey(denom)) continue;

                int needed = remaining / (int)denom;
                int available = _cash[denom];
                int used = Math.Min(needed, available);

                if (used > 0)
                {
                    result[denom] = used;
                    remaining -= used * (int)denom;
                }
            }

            return remaining == 0 ? result : null;
        }
    }
}
