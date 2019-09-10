using Ahorro.Models;
using System;

namespace Ahorro
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            ISaveMoney account = null;

            do
            {
                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine("Este es el menú. Por favor elija una opción:");
                Console.WriteLine("---------------------");
                Console.WriteLine("Para crear tu cuenta: Pulsa 1");
                Console.WriteLine("Para ingresar dinero: Pulsa 2");
                Console.WriteLine("Para sacar dienro: Pulsa 3");
                Console.WriteLine("Para ver tu saldo: Pulsa 4");
                Console.WriteLine("Para salir Pulsa 5");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        int accountType = 1;
                        Console.WriteLine("De que tipo? 1 Bancaria. 2 Hucha");
                        int.TryParse(Console.ReadLine(), out accountType);
                        switch (accountType)
                        {
                            case 1:
                                account = new AccountBank(0);
                                break;
                            case 2:
                                account = new MoneyBox();
                                break;
                        }
                        Console.WriteLine("La cuenta ha sido creada");
                        break;
                    case 2:
                        if (account != null)
                        {
                            Console.WriteLine("¿Cuanto quieres ingresar?");
                            decimal.TryParse(Console.ReadLine(), out decimal amount);
                            account.AddMoney(amount);
                            Console.WriteLine("Se ha ingresado el dinero");
                        }
                        else
                        {
                            Console.WriteLine("No ha creado la cuenta");
                        }
                        break;
                    case 3:
                        if (account != null)
                        {
                            Console.WriteLine("¿Cuanto quieres sacar?");
                            decimal.TryParse(Console.ReadLine(), out decimal amountTakeMoney);
                            try
                            {
                                account.TakeMoney(amountTakeMoney);
                                Console.WriteLine("Se ha sacado el dinero");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se puede sacar tanto dinero");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No ha creado la cuenta");
                        }
                        break;
                    case 4:
                        if (account != null)
                        {
                            Console.WriteLine($"{account.GetBalanceWithText()}");
                        }
                        else
                        {
                            Console.WriteLine("No ha creado la cuenta");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Hasta pronto!");
                        break;
                }
            } while (option != 5);


        }
    }
}
