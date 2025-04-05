using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class TriangleZ
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public TriangleZ(double sideA, double sideB, double sideC)
        {
            if (!IsValidTriangle(sideA, sideB, sideC))
            {
                throw new ArgumentException("Недопустимые размеры треугольника.");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        //Проверка существования треугольника
        private bool IsValidTriangle(double a, double b, double c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a) && (a > 0) && (b > 0) && (c > 0);
        }

        public double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        public double CalculateArea()
        {
            double s = CalculatePerimeter() / 2; // Полупериметр
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC)); // Формула Герона
        }
    }
}
