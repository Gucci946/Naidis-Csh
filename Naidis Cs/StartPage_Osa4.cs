using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("===== KUUD PROGRAMM =====");
            Console.WriteLine("1 - Kirjuta faili");
            Console.WriteLine("2 - Loe faili");
            Console.WriteLine("3 - Muuda listi");
            Console.WriteLine("4 - Otsi kuud");
            Console.WriteLine("5 - Välju");
            Console.Write("Vali tegevus: ");

            string valik = Console.ReadLine();
            Console.WriteLine();

            switch (valik)
            {
                case "1":
                    KuudManager.KirjutaFaili();
                    break;

                case "2":
                    KuudManager.LoeFaili();
                    break;

                case "3":
                    KuudManager.MuudaListi();
                    break;

                case "4":
                    KuudManager.OtsiKuud();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Vale valik!");
                    break;
            }

            Console.WriteLine();
        }
    }
}