namespace Ahorro.Models
{
    public class AccountBank : ISaveMoney
    {
        private const decimal VAT = 10;
        public decimal Balance { get; set; }

        public AccountBank(decimal balance)
        {
            Balance = balance;
        }

        public void AddMoney(decimal amount)
        {
            Balance += amount * ((100 - VAT) / 100);
        }

        public void TakeMoney(decimal amount)
        {
            Balance -= amount;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
