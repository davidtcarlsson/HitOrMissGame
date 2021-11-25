using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
    class Square : IShape
    {
        public string Name { get; } = "SQUARE";
        public double X { get; private set; }
        public double Y { get; private set; }
        public double O { get; private set; }
        public double Area { get => Math.Pow(O / 4, 2); }

        public Square(List<int> args) {
            X = args[0];
            Y = args[1];
            O = args[2];
        }

        public bool IsPointInside(Point point)
        {
            double yMax = Y - (O / 8); 
            double yMin = Y - (O / 8); 
            double xMax = X - (O / 8); 
            double xMin = X - (O / 8); 
            return point.Y <= yMax && point.Y >= yMin && point.X <= xMax && point.X >= xMin;
        }
    }
}