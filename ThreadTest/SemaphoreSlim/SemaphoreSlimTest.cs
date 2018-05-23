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
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(2);

        static void Run()
        {
            // currentVal = Interlocked.CompareExchange(ref target, desiredVal, startVal);
            // 将target的值和startVal的值比较，相等则用desiredVal替换target，否则不操作
            // 不管替换还是不替换返回的都是原来保存在target的值。
            int x = 1;
            var y = Interlocked.CompareExchange(ref x, 2, 1);

            for (int i = 0; i <= 6; i++)
            {
                string threadName = "Thread" + i;
                int secondsToWait = 2 + 2 * i;
                var t = new Thread(() => ShowMessage(threadName, secondsToWait));
                t.Start();
            }

            Console.ReadLine();
        }

        static void ShowMessage(string name, int second)
        {
            Console.WriteLine("{0} watis to showmessage", name);
            semaphoreSlim.Wait();
            Console.WriteLine("{0} was showmessage", name);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("{0} is completed", name);
            semaphoreSlim.Release();
        }

    }
}
