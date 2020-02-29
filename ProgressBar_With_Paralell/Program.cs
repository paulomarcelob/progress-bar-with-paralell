using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressBar_With_Paralell
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var progress = new ProgressBar())
            {
                int counter = 0;
                int total = 1000;
                Parallel.For(0, total, new ParallelOptions { MaxDegreeOfParallelism = 4 }, i =>
                {
                    Interlocked.Increment(ref counter);
                    progress.Report(counter, total);
                    Thread.Sleep(100);
                });
            }
        }
    }
}
