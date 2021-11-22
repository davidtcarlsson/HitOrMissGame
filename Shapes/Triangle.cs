using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
    class Triangle : IShape
    {
        public string typeName = "TRIANGLE";
        public int X { get; private set; }
        public int Y { get; private set; }
        public int O { get; private set; }

        public Triangle(List<int> args) {
            X = args[0];
            Y = args[1];
            O = args[2];
        }

        public bool IsPointInside(Point point)
        {
            // NOT ADDED
            return true;
        }

        public double GetArea() {
            return Math.Pow(O / 3, 2) * Math.Sqrt(3) / 4; 
        }

        public string GetName() 
        {
            return typeName;
        }
    }
}