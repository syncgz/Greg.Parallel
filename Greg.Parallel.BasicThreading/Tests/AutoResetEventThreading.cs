using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Greg.Parallel.BasicThreading.Tests
{

    //
    // AutoResetEvent dziala jak bramki w metrze. Kazdy moze sygnalizowac Set(). Blokada jest zwalniana tylko dla jednego watku. 
    //
    public class AutoResetEventThreading: IThreadTesting
    {
        private Thread t1, t2;

        private AutoResetEvent are = new AutoResetEvent(false);

        public void Initialization()
        {
            t1 = new Thread(Start1);
            t2 = new Thread(Start2);

            t1.Start("A");
            t2.Start("B");
        }

        private void Start1(object o)
        {
            Console.WriteLine("Thread started:" + o.ToString());
            // oczekiwanie na otwarcie - jezeli na otwarcie nie czeka zaden watek to bramka jest nadal otwarta dla pierwszego nadchodzacego watku.
            // Jezeli wywolamy kilka razy Set() to i tak zostanie przepuszczony tylko jeden watek.
            are.WaitOne();
        }
        private void Start2(object o)
        {
            Console.WriteLine("Thread started:" + o.ToString());
            Console.WriteLine("Waiting...");
            Thread.Sleep(1000);
            Console.WriteLine("Signaling..");
            // zasygnalizowanie zwolnienia blokady dla jednego watku
            are.Set();
        }

        public void Execution()
        {
            
        }

        public void Finishing()
        {
            // disposowanie handlera gdy juz nie jest potrzebny
            are.Close();
        }
    }
}
