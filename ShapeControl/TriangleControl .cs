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
    public partial class TriangleControl : UserControl
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

       
    }
}
