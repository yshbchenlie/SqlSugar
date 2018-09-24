using SyntacticSugar;
using System;

namespace OrmTest.PerformanceTesting
{
    public class PerformanceBase
    {
        public int count = 100;
        public void Execute(string title, Action fun)
        {
            PerformanceTest ptef = new PerformanceTest();
            ptef.SetCount(count);//执行count次
            ptef.Execute(
                        i =>
                        {
                            fun();

                        },
                        res =>
                        {
                            Console.WriteLine(string.Format("Execute {0} time，{1}{2}", count, title, res));
                        });

        }
    }
}
