using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
    class Square : IShape
    {
        public string Name { get; } = "SQUARE";
        public int X { get; private set; }
        public int Y { get; private set; }
        public int O { get; private set; }
        public double Area { get => Math.Pow(O / 4, 2); }

        public Square(List<int> args) {
            X = args[0];
            Y = args[1];
            O = args[2];
        }

        public bool IsPointInside(Point point)
        {
            double yMax = (O / 8) + Y; 
            double yMin = (O / 8) - Y; 
            double xMax = (O / 8) + X; 
            double xMin = (O / 8) - X; 
            return point.Y <= yMax && point.Y >= yMin && point.X <= xMax && point.X >= xMin;
        }
    }
}