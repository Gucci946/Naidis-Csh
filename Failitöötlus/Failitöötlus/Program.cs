using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Ülesanne 1
        Console.WriteLine("Sisesta üks Itaalia toidu nimi:");
        string toit = Console.ReadLine();

        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string retseptidPath = Path.Combine(basePath, "Retseptid.txt");

        try
        {
            StreamWriter writer = new StreamWriter(retseptidPath, true);
            writer.WriteLine(toit);
            writer.Close();

            Console.WriteLine("Toit salvestati faili!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Viga faili kirjutamisel: " + ex.Message);
        }


        // Ülesanne 2
        Console.WriteLine("\n--- Kogu menüü failist ---");

        try
        {
            StreamReader reader = new StreamReader(retseptidPath);
            string sisu = reader.ReadToEnd();
            reader.Close();

            Console.WriteLine(sisu);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Faili lugemisel tekkis viga: " + ex.Message);
        }


        // Ülesanne 3
        string koostisosadPath = Path.Combine(basePath, "Koostisosad.txt");

        List<string> koostisosad = new List<string>();

        try
        {
            string[] read = File.ReadAllLines(koostisosadPath);
            koostisosad = new List<string>(read);
        }
        catch
        {
            Console.WriteLine("Koostisosad.txt faili ei leitud.");
        }

        if (koostisosad.Count > 0)
        {
            koostisosad[0] = "Kvaliteetne oliiviõli";
        }

        koostisosad.Remove("Ketšup");

        Console.WriteLine("\n--- Uuendatud koostisosad ---");
        foreach (string k in koostisosad)
        {
            Console.WriteLine(k);
        }


        // Ülesanne 4
        Console.WriteLine("\nSisesta koostisosa mida otsida:");
        string otsitav = Console.ReadLine();

        if (koostisosad.Contains(otsitav))
        {
            Console.WriteLine("Koostisosa on olemas!");
        }
        else
        {
            Console.WriteLine("Seda koostisosa meil retseptis ei ole.");
        }


        // Ülesanne 5
        try
        {
            File.WriteAllLines(koostisosadPath, koostisosad);
            Console.WriteLine("Uus retsept on edukalt faili salvestatud!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Salvestamisel tekkis viga: " + ex.Message);
        }


        // Ülesanne 6
        string menyyPath = Path.Combine(basePath, "Menuu.txt");

        if (!File.Exists(menyyPath))
        {
            string[] algAndmed =
            {
                "Margherita pitsa;San Marzano tomatid, värske mozzarella, basiilik;8.50",
                "Pasta Carbonara;Spagetid, guanciale, pecorino juust, muna;12.00",
                "Tiramisu;Mascarpone, espresso, savoiardi küpsised;6.50"
            };

            File.WriteAllLines(menyyPath, algAndmed);
        }

        List<Tuple<string, string, double>> menyyList = new List<Tuple<string, string, double>>();

        string[] readMenu = File.ReadAllLines(menyyPath);

        foreach (string rida in readMenu)
        {
            string[] osad = rida.Split(';');

            string nimi = osad[0];
            string koost = osad[1];
            double hind = double.Parse(osad[2]);

            menyyList.Add(Tuple.Create(nimi, koost, hind));
        }

        Console.WriteLine("\n=== ITAALIA RESTORANI MENÜÜ ===\n");

        foreach (var roog in menyyList)
        {
            string roaNimi = roog.Item1;
            string koost = roog.Item2;
            double hind = roog.Item3;

            Console.WriteLine($"{roaNimi.PadRight(30)} {hind} €");
            Console.WriteLine($"   {koost}");
            Console.WriteLine();
        }
    }
}
