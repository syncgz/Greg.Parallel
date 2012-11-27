using System;
using System.Threading;
using Greg.Parallel.Common;

namespace Greg.Parallel.BasicThreading.Tests
{
    //
    // Podstawowe tworzenie watkow. Wlasnoreczne zarzadzanie wszystkim.
    //

    public class BaseThreading:IThreadTesting
    {
        private Thread t;
        private Thread t1;
        private Thread t2;

        public void Initialization()
        {
            // utworzenie nowego watku i zainicializowanie go delegatem funkcji
            t = new Thread(new ThreadStart(Start));

            //przekazywanie danych inicializujacych
            t1 = new Thread(new ParameterizedThreadStart(Start));

            t2 = new Thread(() => Work.JobWithError());
        }

        private void Start(object o)
        {
            Work.Job1(o.ToString());
        }

        private void Start()
        {
            Work.Job1("X");
        }

        public void Execution()
        {
            // rozpoczecie wykonywania watku
            t.Start();

            // rozpoczecie wykonywania nowego watku i przekazanie parametrow
            t1.Start("P");

            // wykonanie watku z wewnetrznym bledem
            t2.Start();
            
            // wykonanie innych operacji w glownym watku
            Work.Job1("Y");

            // oczekiwanie na zakonczenie zadania wykonywanego w watku
            t.Join();
        }

        public void Finishing()
        {
            
        }
    }
}
