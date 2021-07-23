using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unittest.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void IsShapeEquals_Circle_ReturnTrue()
        {
            var shapeFactoryDef = new DefFactoryShapes();
            bool result = shapeFactoryDef.isCircle("circle");

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void ToCheckWeatherTheTypeIS_Shape_ReturnTrue()
        {
            var factoryProducerDef = new DefFactProd();
            bool result = factoryProducerDef.isShape("shape");

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void IsShapeEquals_Rectangle_ReturnTrue()
        {
            var shapeFactoryDef = new DefFactoryShapes();
            bool result = shapeFactoryDef.isRectangle("rectangle");

            Assert.AreEqual(true, result);
        }
    }
}