using System;
using System.IO;
using System.Collections.Generic;

class KuudManager
{
    static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt");

    static KuudManager()
    {
        if (!File.Exists(path))
        {
            File.WriteAllLines(path, new string[]
            {
                "Jaanuar",
                "Veebruar",
                "Märts",
                "Aprill",
                "Mai",
                "Juuni"
            });
        }
    }

    public static void KirjutaFaili()
    {
        try
        {
            using (StreamWriter text = new StreamWriter(path, true))
            {
                Console.Write("Sisesta mingi tekst: ");
                string lause = Console.ReadLine();
                text.WriteLine(lause);
            }

            Console.WriteLine("Tekst lisatud faili.");
        }
        catch (Exception)
        {
            Console.WriteLine("Mingi viga failiga");
        }
    }

    public static void LoeFaili()
    {
        try
        {
            using (StreamReader text = new StreamReader(path))
            {
                string laused = text.ReadToEnd();
                Console.WriteLine(laused);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
        }
    }

    public static List<string> LaeList()
    {
        List<string> kuude_list = new List<string>();

        try
        {
            foreach (string rida in File.ReadAllLines(path))
            {
                kuude_list.Add(rida);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Viga failiga!");
        }

        return kuude_list;
    }

    public static void MuudaListi()
    {
        List<string> kuude_list = LaeList();

        foreach (string kuu in kuude_list)
        {
            Console.WriteLine(kuu);
        }

        kuude_list.Remove("Juuni");

        if (kuude_list.Count > 0)
            kuude_list[0] = "Veeel kuuu";

        Console.WriteLine("------- Pärast muutmist -------");

        foreach (string kuu in kuude_list)
        {
            Console.WriteLine(kuu);
        }

        File.WriteAllLines(path, kuude_list);
        Console.WriteLine("Andmed on salvestatud.");
    }

    public static void OtsiKuud()
    {
        List<string> kuude_list = LaeList();

        Console.Write("Sisesta kuu nimi: ");
        string otsitav = Console.ReadLine();

        if (kuude_list.Contains(otsitav))
            Console.WriteLine("Kuu " + otsitav + " on olemas.");
        else
            Console.WriteLine("Sellist kuud pole.");
    }
}