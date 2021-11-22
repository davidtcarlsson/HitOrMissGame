using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
    class Circle : IShape
    {
        public string typeName = "CIRCLE";
        public int X { get; private set; }
        public int Y { get; private set; }
        public int O { get; private set; }

        public Circle(List<int> args) {
            X = args[0];
            Y = args[1];
            O = args[2];
        }

        public bool IsPointInside(Point point)
        {
            return Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2) <= Math.Pow(O, 2) / (4 * Math.Pow(Math.PI, 2));
        }

        public double GetArea() {
            return Math.Pow(O, 2) / (4 * Math.PI);
        }

        public string GetName() 
        {
            return typeName;
        }

    }
}