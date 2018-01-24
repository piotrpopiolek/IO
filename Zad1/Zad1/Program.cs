﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(ThreadProc, 100);
            ThreadPool.QueueUserWorkItem(ThreadProc, 1000);
            Thread.Sleep(1500);
            Console.ReadKey();
        }
        static void ThreadProc(Object stateInfo)
        {
            Thread.Sleep((int)stateInfo);
            System.Console.WriteLine("Czekam: " + stateInfo);
        }
    }
}
