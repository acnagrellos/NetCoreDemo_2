namespace Ahorro.Models
{
    public static class ISaveMoneyExtensions
    {
        public static string GetBalanceWithText(this ISaveMoney saveMoney)
        {
            return $"Tu saldo es {saveMoney.GetBalance()}";
        }

        public static int WordCounts(this string str)
        {
            return str.Split(' ').Length;
        }
    }
}
