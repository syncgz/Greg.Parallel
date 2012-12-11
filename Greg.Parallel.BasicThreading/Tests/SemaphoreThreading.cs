using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Greg.Parallel.BasicThreading.Tests
{
    public class SemaphoreThreading:IThreadTesting
    {
        private SemaphoreSlim _semaphore;

        public void Initialization()
        {
            _semaphore = new SemaphoreSlim(3);

        }

        public void Execution()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(() =>
                    {
                        _semaphore.Wait();
                        Console.WriteLine("Start");
                        Thread.Sleep(3000);
                        Console.WriteLine("End");
                        _semaphore.Release();
                    }).Start();
            }
        }

        public void Finishing()
        {
            //throw new NotImplementedException();
        }
    }
}
