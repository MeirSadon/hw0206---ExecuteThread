using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace hw0206___ThreadExecutor
{
    class ThreadExecutor
    {
        public Queue<Thread> threads = new Queue<Thread>();
        public ThreadExecutor()
        {
            ////Way 1 - Just Function.
            Thread exeThread = new Thread(Execute);

            ////Way 2 - With Timer.
            //System.Timers.Timer t = new System.Timers.Timer(1000);
            //t.AutoReset = true;
            //t.Elapsed += EverySecondWithTimer;
            //t.Start();

            //Way 3 - With ThreadPool.
            //ThreadPool.QueueUserWorkItem(EverySecondWithThreadPool);
        }

        public void AddThread(Thread t)
        {
                threads.Enqueue(t);
        }
        public void Execute()
        {
            lock (this)
            {
                while (threads.Count > 0)
                {
                    Thread t = threads.Dequeue();
                    t.Start();
                    t.Join();
                }
            }                    
        }
        private void EverySecond()
        {
            while (true)
            {
                while (threads.Count > 0)
                {
                    Execute();
                }
                Thread.Sleep(1000);
            }
        }
        private void EverySecondWithTimer(object sender, EventArgs e)
        {
            while (threads.Count > 0)
            {
                Execute();
            }
        }
        private void EverySecondWithThreadPool(object obj)
        {
            while (true)
            {
                lock (this)
                {
                    if (threads.Count > 0)
                    {
                        Execute();
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
