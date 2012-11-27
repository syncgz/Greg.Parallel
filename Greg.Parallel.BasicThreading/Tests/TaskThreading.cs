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
    // Biblioteka ta jest dostepna dopiero od C# 4.0.
    //

    public class TaskThreading : IThreadTesting
    {
        private Task task;

        private Task task2;

        private Task<string> task1; 

        public void Initialization()
        {
            //startowanie watkow
            task = Task.Factory.StartNew(Action);
            
            task1 = Task.Factory.StartNew<string>(Function);

            task2 = Task.Factory.StartNew(Action1);
        }

        public void Execution()
        {
            // Pobieranie rezultatu powoduje blokowanie !!!
            var result = task1.Result;
            
            Work.Job1("Y", 500);
            try
            {
                // W tym momencie zostana zwrocone wszystkie wyjatki ktore zostaly wyrzucone podczas wykonywania zadania.
                // Operacja blokujaca. Jedynie oczekuje na wykonanie zadania, nie zwraca danych.
                task2.Wait(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystapil blad w task2!!!!!!");
            }

            // Oczekiwanie na zakonczenie zadania wykonywanego przez watek. Wykonanie blokujace.
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

        private void Action1()
        {
            Work.JobWithError();
        }

    }
}
