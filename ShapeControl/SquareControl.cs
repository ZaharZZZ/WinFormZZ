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
    public partial class SquareControl : UserControl, IFigureCreator
    {
        public SquareControl()
        {
            InitializeComponent();
            lblSide.Text = "Сторона:";

        }

        public double Side
        {
            get
            {
                if (double.TryParse(txtSide.Text, out double side) && side > 0)
                    return side;
                throw new ArgumentException("Некорректное значение стороны");
            }
            set { txtSide.Text = value.ToString(); }
        }
        public GeometricFigure CreateFigure()
        {
            if (Side <= 0)
                throw new ArgumentException("Сторона квадрата должна быть положительной");

            return new Square(Side);
        }
    }
}
