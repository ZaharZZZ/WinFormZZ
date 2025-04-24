using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeControl
{
    public partial class CircleControl : UserControl, IFigureCreator
    {
        public CircleControl()
        {
            InitializeComponent();

            lblRadius.Text = "Радиус:";
        }

        public double Radius
        {
            get
            {
                if (double.TryParse(txtRadius.Text, out double radius) && radius > 0)
                    return radius;
                throw new ArgumentException("Некорректное значение радиуса");
            }
            set { txtRadius.Text = value.ToString(); }
        }

        public GeometricFigure CreateFigure()
        {
            if (Radius <= 0)
                throw new ArgumentException("Радиус должен быть положительным");

            return new Circle(Radius);
        }


    }
}
