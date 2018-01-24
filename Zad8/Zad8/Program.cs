using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zad8
{
    class Program
    {
        delegate int DelegateType(int arguments);
        static DelegateType f1;
        static DelegateType f2;
        static DelegateType f3;
        static DelegateType f4;
        static int Silnia1(int n)
        {
            int wynik = 1;
            for (int i = 0; i < n; i++)
            {
                wynik *= i;
            }
            return wynik;
        }
        static int Silnia2(int n)
        {
            if (n == 0) return 1;
            else return n * Silnia2(n - 1);
        }
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            f1 = new DelegateType(Silnia1);
            IAsyncResult ar1 = f1.BeginInvoke(999, null, null);
            f2 = new DelegateType(Silnia2);
            IAsyncResult ar2 = f2.BeginInvoke(999, null, null);
            f3 = new DelegateType(Silnia1);
            IAsyncResult ar3 = f3.BeginInvoke(999, null, null);
            f4 = new DelegateType(Silnia2);
            IAsyncResult ar4 = f4.BeginInvoke(999, null, null);
            WaitHandle.WaitAny(new WaitHandle[] { ar1.AsyncWaitHandle, ar2.AsyncWaitHandle, ar3.AsyncWaitHandle, ar4.AsyncWaitHandle });
            sw.Stop();
            Console.WriteLine("{0:00}:{1:00}:{2:000}", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);

            sw.Reset();
            Console.ReadKey();
        }
    }

}
