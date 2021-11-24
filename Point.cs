using System.Collections.Generic;

namespace ProjektarbeteV2
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int PointScore { get; private set; }

        public Point(List<int> args) 
        {
            X = args[0];
            Y = args[1];
            PointScore = args[2];
        }
    }
}