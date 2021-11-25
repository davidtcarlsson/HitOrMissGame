using System.Collections.Generic;

namespace ProjektarbeteV2
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double PointScore { get; private set; }

        public Point(List<double> args) 
        {
            X = args[0];
            Y = args[1];
            PointScore = args[2];
        }
    }
}