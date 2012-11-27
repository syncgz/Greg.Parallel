using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Greg.Parallel.Common;

namespace Greg.Parallel.BasicThreading.Tests
{
    public class AsynchronousDelThreading: IThreadTesting
    {
        public void Initialization()
        {
            // Mozemy dowolnie zamodelowac delegata ktory bedzie wywolany asynchronicznie.
            // Przypisujemy rowniez metoda, ktora ma zostac wykonana.
            Func<string,string> method = Method;
            Func<string, string> method1 = Method;


            // Rozpoczecie wykonywania asynchronicznego.
            // IAsyncResult - umozliwia kontrolowanie wykonania asynchronicznego
            IAsyncResult asyncRes = method.BeginInvoke("X", null, null);

            // Rozpoczecie wykonywania asynchronicznego z wykonanie callbacka po zakonczeniu zadania
            IAsyncResult asyncRes1 = method1.BeginInvoke("X",Callback, new Container(){Name = "1234567890"});

            

            //
            //
            // Wykonujemy tutaj inne dzialania...
            //
            //

            Console.WriteLine("Do some job");

            // oczekiwanie na wynik akcji - blokowanie
            // EndInvoke ma 3 zadania:
            // - oczekiwanie na zakonczenie zadania
            // - zwracanie wartosci przekazanej po wykonaniu zadania
            // - wyrzucenie exceptiona w przypadku gdy on wystpil podczas wykonania
            string result = method.EndInvoke(asyncRes);

            // inna akcja
            Work.Job1("Y");
        }

        private void Callback(IAsyncResult ar)
        {
            // Obiekt ktory zostal przekazany podczas tworzenia watku!!! w tym wypadku Container
            var item = ar.AsyncState;

            // Otrzymanie poszerzonego typu
            var asyncRes = ((AsyncResult) ar);

            // otrzymanie delegatu - potrzebny do wywolania EndInvoke - tak samo jak w normalnym kodzie
            var del = asyncRes.AsyncDelegate as Func<string, string>;

            // Otrzymanie finalnego resultatu z wykonanego zadania.
            var result = del.EndInvoke(ar);
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

    public class Container
    {
        public String Name { get; set; }
    }
}
