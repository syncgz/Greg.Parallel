using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Greg.Parallel.BasicThreading.Tests;
using Greg.Parallel.Common;

namespace Greg.Parallel.BasicThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            IThreadTesting test = new ManulResetEventThreading();

            test.Initialization();
            
            test.Execution();
            
            test.Finishing();

            Console.WriteLine("!!!!!!!!!!Zakonczono wykonywanie probramu!!!!!!!!!!");
            
            Console.ReadLine();

        }
    }
}
