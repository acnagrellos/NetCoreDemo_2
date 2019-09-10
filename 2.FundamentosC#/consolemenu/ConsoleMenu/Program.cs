using System;

namespace ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine("Este es el menú. Por favor elija una opción:");
                Console.WriteLine("---------------------");
                Console.WriteLine("Pulsa 1");
                Console.WriteLine("Pulsa 2");
                Console.WriteLine("Pulsa 3");
                Console.WriteLine("Pulsa 4");
                Console.WriteLine("Para salir Pulsa 5");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Este es el caso 1");
                        break;
                    case 2:
                        Console.WriteLine("Este es el caso 2");
                        break;
                    case 3:
                        Console.WriteLine("Este es el caso 3");
                        break;
                    case 4:
                        Console.WriteLine("Este es el caso 4");
                        break;
                    case 5:
                        Console.WriteLine("Hasta pronto!");
                        break;
                    case 0:
                    default:
                        Console.WriteLine("No se ha introducido bien la opcion a utilizar");
                        break;
                }
            } while (option != 5);
        }
    }
}
