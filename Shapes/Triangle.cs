using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
    class Triangle : IShape
    {
        public string typeName = "CIRCLE";
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
            return true;
        }

        public double GetArea() {
            return 1.0;
        }

        public string GetName() 
        {
            return typeName;
        }

    }
}