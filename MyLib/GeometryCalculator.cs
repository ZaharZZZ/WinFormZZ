﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLib
{
   
        public class Circle : GeometricFigure
        {
            public double Radius { get; private set; }

            public Circle(double radius)
            {
                Name = "Круг";
                AreaFormula = "S = π × r²";
                PerimeterFormula = "P = 2 × π × r";
                Radius = radius;
            }

            public override double CalculateArea()
            {
                return Math.PI * Math.Pow(Radius, 2);
            }

            public override double CalculatePerimeter()
            {
                return 2 * Math.PI * Radius;
            }
        }

        public class RectangleZ : GeometricFigure
        {
            public double Width { get; private set; }
            public double Height { get; private set; }

            public RectangleZ(double width, double height)
            {
                Name = "Прямоугольник";
                AreaFormula = "S = a × b";
                PerimeterFormula = "P = 2 × (a + b)";
                Width = width;
                Height = height;
            }

            public override double CalculateArea()
            {
                return Width * Height;
            }

            public override double CalculatePerimeter()
            {
                return 2 * (Width + Height);
            }
        }

        public class Triangle1X : GeometricFigure
        {
            public double SideA { get; private set; }
            public double SideB { get; private set; }
            public double SideC { get; private set; }

            public Triangle1X(double a, double b, double c)
            {
                Name = "Треугольник";
                AreaFormula = "Формула Герона: S = √(p×(p-a)×(p-b)×(p-c))";
                PerimeterFormula = "P = a + b + c";
                SideA = a;
                SideB = b;
                SideC = c;
            }

            public override double CalculateArea()
            {
                double p = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }

            public override double CalculatePerimeter()
            {
                return SideA + SideB + SideC;
            }
        }

        public class Square : GeometricFigure
        {
            public double Side { get; private set; }

            public Square(double side)
            {
                Name = "Квадрат";
                AreaFormula = "S = a²";
                PerimeterFormula = "P = 4 × a";
                Side = side;
            }

            public override double CalculateArea()
            {
                return Math.Pow(Side, 2);
            }

            public override double CalculatePerimeter()
            {
                return 4 * Side;
            }
        }
}
