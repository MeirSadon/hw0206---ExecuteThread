using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw0206___ThreadExecutor
{
    class Program
    {

        static void Main(string[] args)
        {
            Random r = new Random();
            ThreadExecutor te = new ThreadExecutor();
            for (int i = 0; i < 2; i++)
            {
                te.AddThread(new Thread(() =>
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        Console.WriteLine(j);
                        Thread.Sleep(50);
                    }
                }));
                te.AddThread(new Thread(() => Console.WriteLine("Hello World")));
            }
            while (true)
            {

            }
        }
    }
}
