using Blank.BaseClasses;
using Blank.BaseContracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blank.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        public Circle GetRandomCircle()
        {
            Random r = new Random();

            var radius = r.NextDouble();

            return new Circle(radius);
        }

        public Triangle GetRandomTriangle(double eps = 0)
        {
            Random r = new Random();

            var catA = r.NextDouble();
            var catB = r.NextDouble();
            var hyp = r.NextDouble();

            return new Triangle(catA, catB, hyp, eps);
        }

        public Triangle GetPythagoreanTriangle()
        {
            return new Triangle(3, 4, 5, 0);
        }

        public IFigure GetFigure()
        {
            return GetRandomCircle() as IFigure;
        }

        [Test]
        public void CheckThrowsExceptionWhenCircleRadiusIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
        }

        [Test]
        public void CheckThrowsExceptionWhenOneOfTriangleSidesIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 1, -5));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, -1, 5));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1, 1, 5));
        }

        [Test]
        public void CheckTriangleRectangularityPropertyDontWorkForNonRectangular()
        {
            var t = new Triangle(3, 4, 6);

            Assert.True(!t.IsRight, 
                "Triangle type's 'IsRight' property doesnt work properly for non rectangular samples - got true, must be false");
        }

        [Test]
        public void CheckTriangleRectangularityPropertyDoWorkForRectangular()
        {
            Assert.True(GetPythagoreanTriangle().IsRight,
                "Triangle type's 'IsRight' property doesnt work properly for rectangular sample - got false, must be true");
        }

        [Test]
        public void CheckShapeCalculationWithoutConcreteType()
        {
            double getShape() => GetFigure().Shape;

            Assert.DoesNotThrow(() => getShape());
        }

        [Test]
        public void CheckShapeCalculationOnTriangle()
        {
            double getShape() => GetRandomTriangle().Shape;

            Assert.DoesNotThrow(() => getShape());
        }

        [Test]
        public void CheckShapeCalculationOnCircle()
        {
            double getShape() => GetRandomCircle().Shape;

            Assert.DoesNotThrow(() => getShape());
        }

    }
}
