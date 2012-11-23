using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greg.Parallel.Common;

namespace Greg.Parallel.BasicThreading.Tests
{
    public class AsynchronousDelThreading: IThreadTesting
    {
        public void Initialization()
        {
            Func<string,string> method = Method;

            IAsyncResult asyncRes = method.BeginInvoke("X", null, null);

            //
            //
            // Wykonujemy tutaj inne dzialania...
            //
            //

            Console.WriteLine("Do some job");

            // oczekiwanie na wyniik akcji - blokowanie
            // tutaj rowniez zwracane sa wszystkie wyrzucone wyjatki - one sa rethrowooowane
            string result = method.EndInvoke(asyncRes);

            // inna akcja
            Work.Job1("Y");
        }

        private string Method(string s)
        {
            return Work.Job2();
        }

        public void Execution()
        {
            
        }

        public void Finishing()
        {
            
        }
    }
}
