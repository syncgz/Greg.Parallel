﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Greg.Parallel.Common;

namespace Greg.Parallel.BasicThreading.Tests
{
    //
    // Korzystanie z thread poola nie wykorzystujac TPL. Przydatne gdy tworzymy aplikacje na wersje wczesniejsza niz 4.0
    //

    public class OldThreadPoolThreading : IThreadTesting
    {
        public void Initialization()
        {
            
        }

        public void Execution()
        {
            // tworzenie watkow - uzycie delegatu WaitCallback
            ThreadPool.QueueUserWorkItem(CallBack, "X");
            ThreadPool.QueueUserWorkItem(CallBack, "Y");
            
            Work.Job1("Z");
        }

        public void Finishing()
        {
            
        }

        private void CallBack(object state)
        {
            Work.Job1(state.ToString());
        }


    }
}
