using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Greg.Parallel.Common
{
    public class Work
    {
        public static void Job1(string item)
        {
            Job1(item,100000);
        }

        public static void Job1(string item,int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(item);
                Thread.Sleep(100);
            }
        }

        public static String Job2()
        {
            Thread.Sleep(5000);
            return "Job2";
        }
    }
}
