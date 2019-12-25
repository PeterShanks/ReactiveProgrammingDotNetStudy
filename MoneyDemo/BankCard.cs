using System;

namespace MoneyDemo
{
    public class BankCard : Money
    {
        public Month ValidBefore { get; }

        public BankCard(Month validBefore)
        {
            ValidBefore = validBefore ?? throw new ArgumentNullException(nameof(validBefore));
        }

        public override decimal Withdraw(Currency currency, decimal amount)
        {
            return ValidBefore.CompareTo(DateTime.Now) <= 0 ? 0 : amount;
        }
    }
}