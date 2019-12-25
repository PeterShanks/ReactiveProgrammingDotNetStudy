using System;

namespace MoneyDemo
{
    public class GiftCard: FixedMoney
    {
        public Date ValidBefore { get; }

        public GiftCard(Currency currency, decimal amount, Date validBefore): base(currency, amount)
        {
            ValidBefore = validBefore ?? throw new ArgumentNullException(nameof(validBefore));
        }

        public override decimal Withdraw(Currency currency, decimal amount)
        {
            return 
                ValidBefore.CompareTo(DateTime.Now) <= 0 ?
                    0 :
                    base.Withdraw(currency, amount);
        }
    }
}