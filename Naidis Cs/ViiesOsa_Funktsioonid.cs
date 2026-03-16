using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Naidis_Cs
{
    internal class ViiesOsa_Funktsioonid
    {
        //Add() – lisab elemendi lõppu

        //Contains() – kontrollib, kas element on olemas

        //Count – tagastab elementide arvu

        //Insert(index, item) – lisab elemendi kindlale kohale

        //IndexOf() – otsib elemendi indeksit

        //Sort() – järjestab elemendid kasvavalt
        //static void Main()
        //{
        // List<string> nimed = new List<string>();

        //nimed.Add("Kati");
        //nimed.Add("Mati");
        // nimed.Add("Juku");

        //if (nimed.Contains("Mati"))
        // Console.WriteLine("Mati olemas");

        //Console.WriteLine("Nimesid kokku: " + nimed.Count);

        //nimed.Insert(1, "Sass");

        // Console.WriteLine("Mati indeks: " + nimed.IndexOf("Mati"));
        // Console.WriteLine("Mari indeks: " + nimed.IndexOf("Mari"));

        //foreach (string nimi in nimed)
        //Console.WriteLine(nimi);

        //static void Main()
        //{
        // var route = GetRoute();
        //Console.WriteLine($"Vahemaa: {route.Item1}, Suund: {route.Item2}");
        // }

        //static Tuple<float, char> GetRoute()
        //{
        //float distance = 2.5f;
        // char direction = 'N';

        // return new Tuple<float, char>(distance, direction);
    }
    class Person
    {
        public string Name { get; set; }
    }

    class PeopleListExample
    {
        public void Run()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { Name = "Kadi" });
            people.Add(new Person() { Name = "Mirje" });
            people.Add(new Person() { Name = "Karl" });

            foreach (Person p in people)
            {
                Console.WriteLine(p.Name);
            }
        }
    } 
}
