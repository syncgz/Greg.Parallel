using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greg.Parallel.BasicThreading
{
    public interface IThreadTesting
    {
        void Initialization();
        
        void Execution();
        
        void Finishing();
    }
}
