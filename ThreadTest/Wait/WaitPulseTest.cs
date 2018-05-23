using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest.Wait
{
    public class LockMe
    {
    }

    class WaitPulse1
    {
        private int result = 0;
        private LockMe lM;

        public WaitPulse1()
        {
        }

        public WaitPulse1(LockMe l)
        {
            this.lM = l;
        }

        public void CriticalSection()
        {
            Monitor.Enter(this.lM);
            ////Enter the Critical Section
            Console.WriteLine("WaitPulse1: Entered Thread " + Thread.CurrentThread.GetHashCode());

            for (int i = 1; i <= 5; i++)
            {
                Monitor.Wait(this.lM);
                Console.WriteLine("WaitPulse1: WokeUp");
                Console.WriteLine("WaitPulse1: Result = " + result++ + " ThreadID " + Thread.CurrentThread.GetHashCode());
                Monitor.Pulse(this.lM);
            }
            Console.WriteLine("WaitPulse1: Exiting Thread " + Thread.CurrentThread.GetHashCode());

            //Exit the Critical Section
            Monitor.Exit(this.lM);
        }
    }

    class WaitPulse2
    {
        private int result = 0;
        private LockMe lM;

        public WaitPulse2()
        {
        }

        public WaitPulse2(LockMe l)
        {
            this.lM = l;
        }

        public void CriticalSection()
        {
            Monitor.Enter(this.lM);
            //Enter the Critical Section
            Console.WriteLine("WaitPulse2: Entered Thread "
                + Thread.CurrentThread.GetHashCode());

            for (int i = 1; i <= 5; i++)
            {
                Monitor.Pulse(this.lM);
                Console.WriteLine("WaitPulse2: Result = "
                    + result++
                    + " ThreadID "
                    + Thread.CurrentThread.GetHashCode());
                Monitor.Wait(this.lM);
                Console.WriteLine("WaitPulse2: WokeUp");
            }
            Console.WriteLine("WaitPulse2: Exiting Thread "
                + Thread.CurrentThread.GetHashCode());

            //Exit the Critical Section
            Monitor.Exit(this.lM);
        }
    }

    public class WaitPulseTest
    {
        public static void Run()
        {
            LockMe l = new LockMe();

            WaitPulse1 e1 = new WaitPulse1(l);
            WaitPulse2 e2 = new WaitPulse2(l);

            Thread t1 = new Thread(new ThreadStart(e1.CriticalSection));
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(e2.CriticalSection));
            t2.Start();

            //Wait till the user enters something
            Console.ReadLine();
        }
    }

}
