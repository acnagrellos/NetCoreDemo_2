namespace Ahorro.Models
{
    public interface ISaveMoney
    {
        void AddMoney(decimal amount);
        void TakeMoney(decimal amount);
        decimal GetBalance();
    }
}
