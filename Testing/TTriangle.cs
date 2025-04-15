using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace Testing
{
    [TestClass]
    public class TTriangle
    {
        [TestMethod]
        [DataRow(3, 4, 5, true, DisplayName = "Допустимый треугольник")]
        [DataRow(1, 1, 3, false, DisplayName = "Недопустимый треугольник - Сумма меньше чем сторона")]
        [DataRow(0, 1, 1, false, DisplayName = "Недопустимый треугольник - Сторона с длинной 0")]
        [DataRow(-1, 1, 1, false, DisplayName = "Недопустимый треугольник - Отрицательное значение стороны")]
        public void TriangleExists_WithDataRows(double a, double b, double c, bool expected)
        {
            // Arrange
            Triangle triangle = new Triangle(a, b, c);

            // Act
            bool actual = triangle.Exists();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
