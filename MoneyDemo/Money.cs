using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyDemo
{
    public abstract class Money
    {
        public abstract decimal Withdraw(Currency currency, decimal amount);
    }
}
