using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;

namespace ShapeControl
{
    public partial class TriangleControl : UserControl, IFigureCreator
    {
        public TriangleControl()
        {
            InitializeComponent();

            lblSideA.Text = "Сторона A:";
            lblSideB.Text = "Сторона B:";
            lblSideC.Text = "Сторона C:";
        }

        public double SideA
        {
            get
            {
                if (double.TryParse(txtSideA.Text, out double side) && side > 0)
                    return side;
                throw new ArgumentException("Некорректное значение стороны A");
            }
            set { txtSideA.Text = value.ToString(); }
        }

        public double SideB
        {
            get
            {
                if (double.TryParse(txtSideB.Text, out double side) && side > 0)
                    return side;
                throw new ArgumentException("Некорректное значение стороны B");
            }
            set { txtSideB.Text = value.ToString(); }
        }

        public double SideC
        {
            get
            {
                if (double.TryParse(txtSideC.Text, out double side) && side > 0)
                    return side;
                throw new ArgumentException("Некорректное значение стороны C");
            }
            set { txtSideC.Text = value.ToString(); }
        }

        public GeometricFigure CreateFigure()
        {
            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
                throw new ArgumentException("Стороны треугольника должны быть положительными");

            if (!IsValidTriangle(SideA, SideB, SideC))
                throw new ArgumentException("Треугольник с такими сторонами не существует");

            return new Triangle1X(SideA, SideB, SideC);
        }

        private bool IsValidTriangle(double a, double b, double c)
            => a + b > c && a + c > b && b + c > a;
    }
}
