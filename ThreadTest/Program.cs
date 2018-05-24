using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadTest.ResetEventTest;
using ThreadTest.SemaphoreSlimA;
using ThreadTest.Wait;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {

            // SemaphoreSlimTest.Run();
            //WaitPulseTest.Run();
            MyResetEventTest.Run();
        }
    }
}
