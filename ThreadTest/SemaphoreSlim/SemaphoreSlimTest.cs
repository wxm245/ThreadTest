using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest.SemaphoreSlimA
{
    public class SemaphoreSlimTest
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(0);

        public static void Run()
        {
            for (int i = 0; i <= 6; i++)
            {
                string threadName = "Thread" + i;
                int secondsToWait = 2 + 2 * i;
                var t = new Thread(() => ShowMessage(threadName, secondsToWait).Wait());
                t.Start();
            }

            Console.ReadLine();
        }

        static async Task ShowMessage(string name, int second)
        {
            Console.WriteLine("{0} watis to showmessage", name);
            //semaphoreSlim.Wait();
            await semaphoreSlim.WaitAsync();
            semaphoreSlim.Release();
            Console.WriteLine("{0} was showmessage", name);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("{0} is completed", name);
 
        }

        static void Release()
        {
            semaphoreSlim.Release();
        }

    }
}
