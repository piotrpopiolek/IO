using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zad5
{
    class Program
    {
        private static int rozmiar;
        private static int liczbaElementow;
        private static int[] tablica = null;
        private static Random random;
        private static List<AutoResetEvent> are;
        private static int suma;
        private static List<int> lista;


        static void Main(string[] args)
        {
            Console.WriteLine("Podaj rozmiar tablicy: ");
            rozmiar = Convert.ToInt32(Console.ReadLine());
            lista = new List<int>();

            tablica = new int[rozmiar];
            suma = 0;

            fillRandom();
            printTable();

            Console.WriteLine("Podaj ile liczb mam dodać: ");
            liczbaElementow = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < liczbaElementow; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(SumNumbers));
                Thread.Sleep(200);
            }
            Console.WriteLine("Suma: " + suma);
            Console.ReadKey();
        }

        static void fillRandom()
        {
            random = new Random();
            for (int i = 0; i < rozmiar; i++)
            {
                tablica[i] = random.Next(0, 1000);
            }
        }

        static void printTable()
        {
            for (int i = 0; i < rozmiar; i++)
            {
                Console.Write(tablica[i] + "\t");
            }
            Console.WriteLine();
        }

        static void SumNumbers(object obj)
        {
            object lockObj = new object();
            lock (lockObj)
            {
                Random sRnd = new Random();
                int index = sRnd.Next(1, rozmiar - 1);
                suma += tablica[index];
                Console.WriteLine("Indeks: {0} Wartość: {1}", index, tablica[index]);
            }
        }
    }
}