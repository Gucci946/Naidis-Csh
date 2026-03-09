using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string retseptidPath = Path.Combine(basePath, "Retseptid.txt");
        string koostisosadPath = Path.Combine(basePath, "Koostisosad.txt");
        string menyyPath = Path.Combine(basePath, "Menuu.txt");

        // Ülesanne 1
        Console.Write("Sisesta üks Itaalia toidu nimi: ");
        string toit = Console.ReadLine();

        try
        {
            File.AppendAllText(retseptidPath, toit + Environment.NewLine);
            Console.WriteLine("Toit salvestati faili!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Viga faili kirjutamisel: {ex.Message}");
        }

        // Ülesanne 2
        Console.WriteLine("\n--- Kogu menüü failist ---");
        try
        {
            if (File.Exists(retseptidPath))
                Console.WriteLine(File.ReadAllText(retseptidPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Faili lugemisel tekkis viga: {ex.Message}");
        }

        // Ülesanne 3
        List<string> koostisosad = new List<string>();

        try
        {
            if (File.Exists(koostisosadPath))
                koostisosad.AddRange(File.ReadAllLines(koostisosadPath));
            else
                Console.WriteLine("Koostisosad.txt faili ei leitud.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Viga faili lugemisel: {ex.Message}");
        }

        if (koostisosad.Count > 0)
            koostisosad[0] = "Kvaliteetne oliiviõli";

        koostisosad.Remove("Ketšup");

        Console.WriteLine("\n--- Uuendatud koostisosad ---");
        foreach (var k in koostisosad)
            Console.WriteLine(k);

        // Ülesanne 4
        Console.Write("\nSisesta koostisosa mida otsida: ");
        string otsitav = Console.ReadLine();

        Console.WriteLine(koostisosad.Contains(otsitav)
            ? "Koostisosa on olemas!"
            : "Seda koostisosa meil retseptis ei ole.");

        // Ülesanne 5
        try
        {
            File.WriteAllLines(koostisosadPath, koostisosad);
            Console.WriteLine("Uus retsept on edukalt faili salvestatud!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Salvestamisel tekkis viga: {ex.Message}");
        }

        // Ülesanne 6
        if (!File.Exists(menyyPath))
        {
            File.WriteAllLines(menyyPath, new[]
            {
                "Margherita pitsa;San Marzano tomatid, värske mozzarella, basiilik;8.50",
                "Pasta Carbonara;Spagetid, guanciale, pecorino juust, muna;12.00",
                "Tiramisu;Mascarpone, espresso, savoiardi küpsised;6.50"
            });
        }

        var menyyList = new List<(string nimi, string koost, double hind)>();

        foreach (var rida in File.ReadAllLines(menyyPath))
        {
            var osad = rida.Split(';');

            if (osad.Length == 3 && double.TryParse(osad[2], out double hind))
                menyyList.Add((osad[0], osad[1], hind));
        }

        Console.WriteLine("\n=== ITAALIA RESTORANI MENÜÜ ===\n");

        foreach (var roog in menyyList)
        {
            Console.WriteLine($"{roog.nimi.PadRight(30)} {roog.hind:F2} €");
            Console.WriteLine($"   {roog.koost}");
            Console.WriteLine();
        }
    }
}
