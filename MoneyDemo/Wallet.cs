using System.Collections.Generic;

namespace MoneyDemo
{
    public class Wallet
    {
        private IList<Money> Content { get; } = new List<Money>();

        public void Charge(Currency currency, decimal amount)
        {
            decimal remaining = amount;

            using (IEnumerator<Money> money = Content.GetEnumerator())
            {
                while (money.MoveNext() && remaining > 0)
                {
                    decimal paid = money.Current.Withdraw(currency, remaining);
                    remaining -= paid;
                }
            }
        }
    }
} 