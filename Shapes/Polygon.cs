using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
	class Polygon : IShape
	{
        public string Name { get; private set; }
        public double Area { get => (Math.Pow(SideLength, 2) * NumSides) / (4 * Math.Tan(Math.PI / NumSides)); }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double O { get; private set; }
        public double NumSides{ get; private set; }
        public double SideLength{ get => O / NumSides; }
        public double Circumradius { get =>  SideLength / 2 * Math.Sin(Math.PI / NumSides); }
        public List<Point> Vertices { get; private set; } 

        public Polygon(string name, List<double> args)
        {
            X = args[0];
            Y = args[1];
            O = args[2];
            Name = name;
            NumSides = GetNumSides();
            Vertices = GetVertices();
        }

        public bool IsPointInside(Point point)
        {
            bool result = false;
            int j = Vertices.Count - 1;
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].Y < point.Y && Vertices[j].Y >= point.Y || Vertices[j].Y < point.Y && Vertices[i].Y >= point.Y)
                {
                    if (Vertices[i].X + (point.Y - Vertices[i].Y) / (Vertices[j].Y - Vertices[i].Y) * (Vertices[j].X - Vertices[i].X) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public double GetNumSides()
        {
            switch (Name)
            {
                case "TRIANGLE":
                    return 3;
                case "SQUARE":
                    return 4;
                case "PENTAGON":
                    return 5;
                case "HEXAGON":
                    return 6;
                case "HEPTAGON":
                    return 7;
                case "OCTAGON":
                    return 8;
                default:
                    Console.WriteLine("Error");
                    return 0;
            }
        }
      
        public List<Point> GetVertices()
        {
            List<Point> vertices = new List<Point>();
            double xCorner;
            double yCorner;
            double Angles = (2 * Math.PI) / NumSides;
            double Offset;

            // Vinkel i radianer
			if (NumSides % 2 == 0)
			{
                Offset = Angles / 2;
			}
			else
			{
                Offset = 0;
			}

			for (int i = 0; i < NumSides; i++)
			{
                xCorner = (X + Circumradius * Math.Sin(i * Angles + Offset));
                yCorner = (Y + Circumradius * Math.Cos(i * Angles + Offset));

                // Creating a list that will be used to create a point object
                List<double> pointArgs = new List<double>();
                pointArgs.Add(xCorner);
                pointArgs.Add(yCorner);
                pointArgs.Add(0);
                vertices.Add(new Point(pointArgs));
            }
            return vertices;
        }
    }
}
