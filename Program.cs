using System;
using System.Collections.Generic;

namespace InventariDyqanit
{
    // Klasa e produktit
    class Produkt
    {
        public int Id;
        public string Emri;
        public double Cmimi;
        public int Sasia;
    }

    // KLASA STATIKE qe ruan te dhenat (ne vend te databazes).
    // Ketu jane te 4 operacionet baze: CREATE, READ, UPDATE, DELETE.
    static class Inventari
    {
        // Lista ku ruhen produktet
        static List<Produkt> produktet = new List<Produkt>();

        // Numri qe perdoret per ID
        static int idAktual = 1;

        // CREATE - shton nje produkt
        public static void Shto(string emri, double cmimi, int sasia)
        {
            Produkt p = new Produkt();
            p.Id = idAktual;
            idAktual++;
            p.Emri = emri;
            p.Cmimi = cmimi;
            p.Sasia = sasia;

            produktet.Add(p);
        }

        // READ - kthen te gjithe produktet
        public static List<Produkt> Lexo()
        {
            return produktet;
        }

        // UPDATE - ndryshon nje produkt sipas ID-se. Kthen true nese u gjet.
        public static bool Ndrysho(int id, string emri, double cmimi, int sasia)
        {
            foreach (Produkt p in produktet)
            {
                if (p.Id == id)
                {
                    p.Emri = emri;
                    p.Cmimi = cmimi;
                    p.Sasia = sasia;
                    return true;
                }
            }
            return false;
        }

        // DELETE - fshin nje produkt sipas ID-se. Kthen true nese u gjet.
        public static bool Fshi(int id)
        {
            foreach (Produkt p in produktet)
            {
                if (p.Id == id)
                {
                    produktet.Remove(p);
                    return true;
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            bool vazhdo = true;

            while (vazhdo)
            {
                Console.WriteLine("\n===== INVENTARI I DYQANIT =====");
                Console.WriteLine("1. Shto produkt   (Create)");
                Console.WriteLine("2. Shfaq produktet (Read)");
                Console.WriteLine("3. Ndrysho produkt (Update)");
                Console.WriteLine("4. Fshi produkt    (Delete)");
                Console.WriteLine("0. Dil");
                Console.Write("Zgjedhja: ");

                string zgjedhja = Console.ReadLine();

                if (zgjedhja == "1")
                    ShtoProdukt();
                else if (zgjedhja == "2")
                    ShfaqProduktet();
                else if (zgjedhja == "3")
                    NdryshoProdukt();
                else if (zgjedhja == "4")
                    FshiProdukt();
                else if (zgjedhja == "0")
                    vazhdo = false;
                else
                    Console.WriteLine("Zgjedhje e gabuar!");
            }
        }

        // CREATE
        static void ShtoProdukt()
        {
            Console.Write("Emri: ");
            string emri = Console.ReadLine();
            double cmimi = LexoDouble("Cmimi: ");
            int sasia = LexoInt("Sasia: ");

            Inventari.Shto(emri, cmimi, sasia);
            Console.WriteLine("Produkti u shtua!");
        }

        // READ
        static void ShfaqProduktet()
        {
            List<Produkt> lista = Inventari.Lexo();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nuk ka produkte.");
                return;
            }

            foreach (Produkt p in lista)
            {
                Console.WriteLine("ID: " + p.Id + " | " + p.Emri + " | Cmimi: " + p.Cmimi + " | Sasia: " + p.Sasia);
            }
        }

        // UPDATE
        static void NdryshoProdukt()
        {
            int id = LexoInt("Jep ID-ne e produktit: ");

            Console.Write("Emri i ri: ");
            string emri = Console.ReadLine();
            double cmimi = LexoDouble("Cmimi i ri: ");
            int sasia = LexoInt("Sasia e re: ");

            bool sukses = Inventari.Ndrysho(id, emri, cmimi, sasia);
            if (sukses)
                Console.WriteLine("Produkti u ndryshua!");
            else
                Console.WriteLine("Nuk u gjet produkti.");
        }

        // DELETE
        static void FshiProdukt()
        {
            int id = LexoInt("Jep ID-ne e produktit: ");

            bool sukses = Inventari.Fshi(id);
            if (sukses)
                Console.WriteLine("Produkti u fshi!");
            else
                Console.WriteLine("Nuk u gjet produkti.");
        }

        // Metode ndihmese: lexon nje numer te plote dhe e perserit nese eshte gabim
        static int LexoInt(string mesazh)
        {
            int numer;
            Console.Write(mesazh);
            while (!int.TryParse(Console.ReadLine(), out numer))
            {
                Console.Write("Gabim! Shkruaj nje numer: ");
            }
            return numer;
        }

        // Metode ndihmese: lexon nje numer me presje dhe e perserit nese eshte gabim
        static double LexoDouble(string mesazh)
        {
            double numer;
            Console.Write(mesazh);
            while (!double.TryParse(Console.ReadLine(), out numer))
            {
                Console.Write("Gabim! Shkruaj nje numer: ");
            }
            return numer;
        }
    }
}
