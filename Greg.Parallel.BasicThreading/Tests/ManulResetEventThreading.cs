using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Greg.Parallel.BasicThreading.Tests
{
    //
    // ManualResetEventHandler - posiada dwa stany, otwarty oraz zamkniety.
    //

    public class ManulResetEventThreading:IThreadTesting
    {
        private ManualResetEvent _mre;

        public void Initialization()
        {
            // inicializacja eventu stanem poczatkowym
            _mre = new ManualResetEvent(false);
        }

        public void Execution()
        {
            Thread slave = new Thread(Slave);
            slave.Start();
            Console.WriteLine("Wykonanie jakiejs roboty...");
            Thread.Sleep(3000);
            Console.WriteLine("Zakonczenie wykonania...");
            // uzycie funkcji Set() powoduje permanentne otworzenie eventa i odblokowanie wszystki zablokowanych watkow...event jest odblokowany dopuki nie zostanie wywolana funkcja Reset()
            _mre.Set();

        }

        private void Slave()
        {
            // oczekiwanie na otwarcie eventa
            Console.WriteLine("Oczekiwanie na otwarcie eventa.");
            _mre.WaitOne();
            Console.WriteLine("Event zostal odblokowany...");

        }

        public void Finishing()
        {
            Thread.Sleep(1000);
            // disposowanie eventa
            _mre.Reset();
        }
    }
}
