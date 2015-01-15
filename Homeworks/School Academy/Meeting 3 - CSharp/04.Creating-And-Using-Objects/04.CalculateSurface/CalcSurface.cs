using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CalculateSurface
{
    public class CalcSurface
    {
        public double surface;
        public double halfP;

        public CalcSurface(int firstSide, int secondSide, int thirdSide)
        {
            halfP = (firstSide + secondSide + thirdSide) / 2;
            surface = Math.Sqrt(halfP * (halfP - firstSide) * (halfP - secondSide) * (halfP - thirdSide));
        }

        public CalcSurface(int firstSide, int altitude)
        {
            surface = (firstSide * altitude) / 2;
        }

        public CalcSurface(int firstSide, int secondSide, double angle)
        {
            surface = (firstSide * secondSide * Math.Sin(angle)) / 2 ;
        }

        public double GetSurface()
        {
                return surface;
        }
    }
    class Calc
    {
        static void Main()
        {
            double surface;
            Console.WriteLine("These are the surfaces of triangles with given:");
            Console.WriteLine("");
            CalcSurface firstTriangle = new CalcSurface(5, 2);
            surface = firstTriangle.GetSurface();
            Console.WriteLine(" -side and altitude: {0:F2}", surface);

            Console.WriteLine("");

            CalcSurface secondTriangle = new CalcSurface(12, 10, 6);
            surface = secondTriangle.GetSurface();
            Console.WriteLine(" -three sides: {0:F2}", surface);

            Console.WriteLine("");

            CalcSurface thirdTriangle = new CalcSurface(2, 3, 45.0);
            surface = thirdTriangle.GetSurface();
            Console.WriteLine(" -two sides and angle between them: {0:F2}", surface);
            Console.WriteLine("");
        }
    }
}
