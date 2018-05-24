using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest.ResetEventTest
{
    public class MyResetEventTest
    {
        static EventWaitHandle _tollStation = new ManualResetEvent(false);

        public static void Run()
        {
            new Thread(Car1).Start();
            new Thread(Car2).Start();
            _tollStation.Set();
            Console.ReadKey();
        }

        static void Car1()
        {
            _tollStation.WaitOne();//等待开启车闸，即_tollStation.Set();
            Console.WriteLine("车辆1，顺利通过。");
            //_tollStation.Set();//再开启一次车闸，让车辆2通过
        }

        static void Car2()
        {
            _tollStation.WaitOne();
            Console.WriteLine("车辆2，顺利通过。");
        }
    }
}
