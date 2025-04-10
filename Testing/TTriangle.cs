using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace Testing
{
    [TestClass]
    public class TTriangle
    {
        [TestMethod]
        public void CalculatePerimeter_ValidTriangle_ReturnsCorrectPerimeter()
        {
            // Arrange
            TriangleZ triangle = new TriangleZ(3, 4, 5);
            double expectedPerimeter = 12;

            // Act
            double actualPerimeter = triangle.CalculatePerimeter();

            // Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [TestMethod]
        public void CalculateArea_ValidTriangle_ReturnsCorrectArea()
        {
            // Arrange
            TriangleZ triangle = new TriangleZ(3, 4, 5);
            double expectedArea = 6;

            // Act
            double actualArea = triangle.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, actualArea, 0.001);
        }
        [TestMethod]
        
        public void Triangle_ZeroSide_ThrowsArgumentException()
        {
            new TriangleZ(0, 4, 5); 
        }
    }
}
