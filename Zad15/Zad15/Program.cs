﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Zad15
{
    class Program
    {

        static void Main(string[] args)
        {
            Server s = new Server();
            Task.WaitAll(s.RunAsync());


        }
    }
}