using System;
using Blank.BaseContracts;

namespace Blank.BaseClasses
{
    public class Circle : IFigure
    {
        public double Perimeter => 2 * Math.PI  * Radius;

        public double Shape => Math.PI * Math.Pow(Radius, 2);

        private double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Radius), "Value cannot be lower than zero");

                radius = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }
    }

    public class Triangle : IFigure, ITriangle
    {
        public bool IsRight => PythigoreanRectangularityOfTriangle(cathetusA, cathetusB, hypotenuse, calcEpsilon);

        public double Perimeter => cathetusA + cathetusB + hypotenuse;

        public double Shape
        {
            get
            {
                var p = Perimeter * 0.5;
                var square = p * (p - cathetusA) * (p - cathetusB) * (p - hypotenuse);
                return Math.Sqrt(square);
            }
        }

        private double cathetusA;
        public double CathetusA
        {
            get { return cathetusA; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(CathetusA), "Value cannot be lower than zero");

                cathetusA = value;
            }
        }

        private double cathetusB;
        public double CathetusB
        {
            get { return cathetusB; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(CathetusB), "Value cannot be lower than zero");

                cathetusB = value;
            }
        }

        private double hypotenuse;
        public double Hypotenuse
        {
            get { return hypotenuse; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Hypotenuse), "Value cannot be lower than zero");

                hypotenuse = value;
            }
        }

        private double calcEpsilon;

        public double CalcEpsilon
        {
            get { return calcEpsilon; }
            set { calcEpsilon = Math.Abs(value); }
        }

        public Triangle(double cathetusA, double cathetusB, double hypotenuse, double calcEpsilon = 0)
        {
            CathetusA = cathetusA;
            CathetusB = cathetusB;
            Hypotenuse = hypotenuse;
            CalcEpsilon = Math.Abs(calcEpsilon);
        }

        public static bool PythigoreanRectangularityOfTriangle(double cathetusA, double cathetusB, double hypotenuse, double epsilon = 0)
        {
            return (Math.Pow(hypotenuse, 2) - (Math.Pow(cathetusA, 2) + Math.Pow(cathetusB, 2))) <= epsilon;
        }
    }
}
