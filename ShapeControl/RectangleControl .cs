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
    public partial class RectangleControl : UserControl, IFigureCreator
    {
        public RectangleControl()
        {
            InitializeComponent();

            lblWidth.Text = "Ширина:";
            lblHeight.Text = "Высота:";
        }

        public double Width
        {
            get
            {
                if (double.TryParse(txtWidth.Text, out double width) && width > 0)
                    return width;
                throw new ArgumentException("Некорректное значение ширины");
            }
            set { txtWidth.Text = value.ToString(); }
        }

        public double Height
        {
            get
            {
                if (double.TryParse(txtHeight.Text, out double height) && height > 0)
                    return height;
                throw new ArgumentException("Некорректное значение высоты");
            }
            set { txtHeight.Text = value.ToString(); }
        }
        public GeometricFigure CreateFigure()
        {
            if (Width <= 0 || Height <= 0)
                throw new ArgumentException("Ширина и высота должны быть положительными");

            return new RectangleZ(Width, Height);
        }
    }
}
