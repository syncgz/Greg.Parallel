using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Greg.Parallel.Common;

namespace Greg.Parallel.BasicThreading.Tests
{
    public class LockingThread:IThreadTesting
    {
        private int occ = 0;

        public void Initialization()
        {
            var t1 = new Thread(() => Work.Job1("A", 200));
            var t2 = new Thread(() => Work.Job1("B", 200));

            t1.Start();
            t2.Start();
        }

        public void Execution()
        {
            
        }

        public void Finishing()
        {
            
        }
    }
}
