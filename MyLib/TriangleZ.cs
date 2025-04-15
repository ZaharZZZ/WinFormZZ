using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Triangle
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public bool Exists()
        {
            return SideA + SideB > SideC &&
                   SideA + SideC > SideB &&
                   SideB + SideC > SideA &&
                   SideA > 0 && SideB > 0 && SideC > 0;
        }
    }
}
