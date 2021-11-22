using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
    class Square : IShape
    {
        public string typeName = "SQUARE";
        public int X { get; private set; }
        public int Y { get; private set; }
        public int O { get; private set; }

        public Square(List<int> args) {
            X = args[0];
            Y = args[1];
            O = args[2];
        }

        public bool IsPointInside(Point point)
        {
            return true;
        }

        public double GetArea() {
            return Math.Pow(O / 4, 2);
        }

        public string GetName() 
        {
            return typeName;
        }

    }
}