using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public abstract class GeometricFigure
    {
        public string Name { get; protected set; }
        public string AreaFormula { get; protected set; }
        public string PerimeterFormula { get; protected set; }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();

        public virtual string GetInfo()
        {
            return $"{Name}\nПлощадь: {AreaFormula}\nПериметр: {PerimeterFormula}";
        }
    }
}
