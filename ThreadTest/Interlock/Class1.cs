using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest.InterlockedTest
{
    class Class1
    {
        public static void Run()
        {
            // currentVal = Interlocked.CompareExchange(ref target, desiredVal, startVal);
            // 将target的值和startVal的值比较，相等则用desiredVal替换target，否则不操作
            // 不管替换还是不替换返回的都是原来保存在target的值。
            int x = 1;
            var y = Interlocked.CompareExchange(ref x, 2, 1);
        }
    }
}
