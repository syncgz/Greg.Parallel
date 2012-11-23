using System;
using System.Threading;
using Greg.Parallel.Common;

namespace Greg.Parallel.BasicThreading.Tests
{
    //
    // Podstawowe tworzenie watkow. Wlasnoreczne zarzadzanie wszystkim.
    //

    public class BaseTreading:IThreadTesting
    {
        private Thread t;

        public void Initialization()
        {
            t = new Thread(Start);
        }

        private void Start()
        {
            Work.Job1("X");
        }

        public void Execution()
        {
            t.Start();
            
            Work.Job1("Y");
        }

        public void Finishing()
        {
            
        }
    }
}
