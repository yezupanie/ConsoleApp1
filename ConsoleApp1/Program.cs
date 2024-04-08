using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tablica = GenerujTablice(10);

            Console.WriteLine("Tablica: " + string.Join(", ", tablica));

            int liczbaElementowWiekszychOd5 = tablica.Count(x => x > 5);
            Console.WriteLine("Liczba elementów > 5: " + liczbaElementowWiekszychOd5);

            double sredniaArytmetyczna = tablica.Where(x => x > 5).Average();
            Console.WriteLine("Średnia arytmetyczna z elementów > 5: " + sredniaArytmetyczna);

            double sredniaGeometryczna = SredniaGeometryczna(tablica, 25);
            Console.WriteLine("Średnia geometryczna z elementów 25: " + sredniaGeometryczna);

            var liczbyPierwsze = tablica.Where(x => CzyLiczbaPierwsza(x));
            Console.WriteLine("Liczby pierwsze w tabeli: " + string.Join(", ", liczbyPierwsze));
            Console.Read();
        }

        static int[] GenerujTablice(int rozmiar)
        {
            Random rand = new Random();
            int[] tablica = new int[rozmiar];

            for (int i = 0; i < rozmiar; i++)
            {
                tablica[i] = rand.Next(1, 30);
            }

            return tablica;
        }

        static double SredniaGeometryczna(int[] tablica, int liczba)
        {
            var elementy25 = tablica.Where(x => x == liczba);
            if (elementy25.Any())
            {
                double iloczyn = 1;
                foreach (var element in elementy25)
                {
                    iloczyn *= element;
                }

                return Math.Pow(iloczyn, 1.0 / elementy25.Count());
            }
            else
            {
                return 0;
            }
        }

        static bool CzyLiczbaPierwsza(int liczba)
        {
            if (liczba < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(liczba); i++)
            {
                if (liczba % i == 0)
                    return false;
            }

            return true;
        }
    }
}
