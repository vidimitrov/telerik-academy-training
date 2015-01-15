using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sqrt_Log_And_Sin_Test
{
    class SqrtLogAndSinTest
    {
        static void MeasureOperation(Action act)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            act();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Square root:");
            Console.Write("float: ");
            MeasureOperation(() =>
            {
                Math.Sqrt(1.0f);
            });
            Console.Write("double: ");
            MeasureOperation(() =>
            {
                Math.Sqrt(1.0);
            });
            Console.Write("decimal: ");
            MeasureOperation(() =>
            {
                Math.Sqrt((double)1.0m);
            });

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Natural logarithm:");
            Console.Write("float: ");
            MeasureOperation(() =>
            {
                Math.Log(1.0f);
            });
            Console.Write("double: ");
            MeasureOperation(() =>
            {
                Math.Log(1.0);
            });
            Console.Write("decimal: ");
            MeasureOperation(() =>
            {
                Math.Log((double)1.0m);
            });

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Sinus:");
            Console.Write("float: ");
            MeasureOperation(() =>
            {
                Math.Sin(1.0f);
            });
            Console.Write("double: ");
            MeasureOperation(() =>
            {
                Math.Sin(1.0);
            });
            Console.Write("decimal: ");
            MeasureOperation(() =>
            {
                Math.Sqrt((double)1.0m);
            });
        }
    }
}
