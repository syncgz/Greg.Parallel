using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greg.Parallel.Common;

namespace Greg.Parallel.BasicThreading.Tests
{
    //
    // TPL
    // Wykorzystanie klasy Task. Watki sa pobierane z puli dlatego tez nie ma dodatkowego narzutu podczas tworzenia watkow.
    //

    public class TaskThreading : IThreadTesting
    {
        private Task task;

        private Task<string> task1; 

        public void Initialization()
        {
            //startowanie watkow
            task = Task.Factory.StartNew(Action);
            
            task1 = Task.Factory.StartNew<string>(Function);
        }

        public void Execution()
        {
            // Pobieranie rezultatu powoduje blokowanie !!!
            var result = task1.Result;
            
            Work.Job1("Y", 500);
            
            task.Wait(10000);
        }

        public void Finishing()
        {
            
        }

        private string Function()
        {
            return Work.Job2();
        }

        private void Action()
        {
            Work.Job1("X");
        }

    }
}
