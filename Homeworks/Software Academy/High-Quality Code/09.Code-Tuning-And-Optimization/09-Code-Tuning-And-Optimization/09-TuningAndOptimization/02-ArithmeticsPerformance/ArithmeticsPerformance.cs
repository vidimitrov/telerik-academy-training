using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ArithmeticsPerformance
{

    class ArithmeticsPerformance
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
            int operationsCount = 10000;

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Add:");
            Console.Write("int: ");
            MeasureOperation(() =>
            {
                int value = 0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value += 100;
                }
            });
            Console.Write("long: ");
            MeasureOperation(() =>
            {
                long value = 0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value += 100L;
                }
            });
            Console.Write("float: ");
            MeasureOperation(() =>
            {
                float value = 0.0f;

                for (int i = 0; i < operationsCount; i++)
                {
                    value += 100.0f;
                }
            });
            Console.Write("double: ");
            MeasureOperation(() =>
            {
                double value = 0.0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value += 100.0;
                }
            });
            Console.Write("decimal: ");
            MeasureOperation(() =>
            {
                decimal value = 0m;

                for (int i = 0; i < operationsCount; i++)
                {
                    value += 100.0m;
                }
            });

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Substract:");
            Console.Write("int: ");
            MeasureOperation(() =>
            {
                int value = 0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value -= 100;
                }
            });
            Console.Write("long: ");
            MeasureOperation(() =>
            {
                long value = 0L;

                for (int i = 0; i < operationsCount; i++)
                {
                    value -= 100L;
                }
            });
            Console.Write("float: ");
            MeasureOperation(() =>
            {
                float value = 0.0f;

                for (int i = 0; i < operationsCount; i++)
                {
                    value -= 100.0f;
                }
            });
            Console.Write("double: ");
            MeasureOperation(() =>
            {
                double value = 0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value -= 100.0;
                }
            });
            Console.Write("decimal: ");
            MeasureOperation(() =>
            {
                decimal value = 0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value -= 100.0m;
                }
            });

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Increment:");
            Console.Write("int: ");
            MeasureOperation(() =>
            {
                int value = 0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value++;
                }
            });
            Console.Write("long: ");
            MeasureOperation(() =>
            {
                long value = 0L;

                for (int i = 0; i < operationsCount; i++)
                {
                    value++;
                }
            });
            Console.Write("float: ");
            MeasureOperation(() =>
            {
                float value = 0.0f;

                for (int i = 0; i < operationsCount; i++)
                {
                    value++;
                }
            });
            Console.Write("double: ");
            MeasureOperation(() =>
            {
                double value = 0.0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value++;
                }
            });
            Console.Write("decimal: ");
            MeasureOperation(() =>
            {
                decimal value = 0.0m;

                for (int i = 0; i < operationsCount; i++)
                {
                    value++;
                }
            });

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Multiply:");
            Console.Write("int: ");
            MeasureOperation(() =>
            {
                int value = 0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value *= 1;
                }
            });
            Console.Write("long: ");
            MeasureOperation(() =>
            {
                long value = 0L;

                for (int i = 0; i < operationsCount; i++)
                {
                    value *= 1L;
                }
            });
            Console.Write("float: ");
            MeasureOperation(() =>
            {
                float value = 0.0f;

                for (int i = 0; i < operationsCount; i++)
                {
                    value *= 1.0f;
                }
            });
            Console.Write("double: ");
            MeasureOperation(() =>
            {
                double value = 0.0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value *= 1.0;
                }
            });
            Console.Write("decimal: ");
            MeasureOperation(() =>
            {
                decimal value = 0.0m;

                for (int i = 0; i < operationsCount; i++)
                {
                    value *= 1.0m;
                }
            });

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Divide:");
            Console.Write("int: ");
            MeasureOperation(() =>
            {
                int value = 0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value /= 1;
                }
            });
            Console.Write("long: ");
            MeasureOperation(() =>
            {
                long value = 0L;

                for (int i = 0; i < operationsCount; i++)
                {
                    value /= 1L;
                }
            });
            Console.Write("float: ");
            MeasureOperation(() =>
            {
                float value = 0.0f;

                for (int i = 0; i < operationsCount; i++)
                {
                    value /= 1.0f;
                }
            });
            Console.Write("double: ");
            MeasureOperation(() =>
            {
                double value = 0.0;

                for (int i = 0; i < operationsCount; i++)
                {
                    value /= 1.0;
                }
            });
            Console.Write("decimal: ");
            MeasureOperation(() =>
            {
                decimal value = 0.0m;

                for (int i = 0; i < operationsCount; i++)
                {
                    value /= 1.0m;
                }
            });

        }
    }
}
