using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
    class Circle : IShape
    {
        public string Name { get; } = "CIRCLE";
        public double X { get; private set; }
        public double Y { get; private set; }
        public double O { get; private set; }
        public double Area { get => Math.Pow(O, 2) / (4 * Math.PI); }

        public Circle(List<double> args) {
            X = args[0];
            Y = args[1];
            O = args[2];
        }

        public bool IsPointInside(Point point)
        {
            return Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2) <= Math.Pow(O, 2) / (4 * Math.Pow(Math.PI, 2));
        }
    }
}