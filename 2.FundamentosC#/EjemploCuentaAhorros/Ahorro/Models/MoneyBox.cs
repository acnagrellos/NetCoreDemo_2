using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorro.Models
{
    public class MoneyBox : ISaveMoney
    {
        public decimal Balance { get; set; }

        public void AddMoney(decimal amount)
        {
            Balance += amount;
        }

        public decimal GetBalance() => Balance;

        public void TakeMoney(decimal amount)
        {
            var total = Balance - amount;
            if (total > 0)
            {
                Balance = total;
            }
            else
            {
                throw new Exception("No se puede sacar tanto dinero");
            }
        }
    }
}
