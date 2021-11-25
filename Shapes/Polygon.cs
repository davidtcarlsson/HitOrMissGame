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
        public double SideLength{ get; private set; }
        public double Angles { get; private set; }
        public double Offset { get; private set; }
        public double Circumradius { get =>  SideLength / 2 * Math.Sin(Math.PI / NumSides); }
        public List<Point> Vertices {get; private set; } = new List<Point>();

        public double XCorner;
        public double YCorner;
        public Polygon(string name, List<double> args)
        {
            X = args[0];
            Y = args[1];
            O = args[2];
            Name = name;
            NumOfSides(Name);
            GetVertices();
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

        public void NumOfSides(string name)
        {
            switch (Name)
            {
                case "TRIANGLE":
                    NumSides = 3;
                    SideLength = O / 3;
                    break;
                case "SQUARE":
                    NumSides = 4;
                    SideLength = O / 4;
                    break;
                case "PENTAGON":
                    NumSides = 5;
                    SideLength = O / 5;
                    break;
                case "HEXAGON":
                    NumSides = 6;
                    SideLength = O / 6;
                    break;
                case "HEPTAGON":
                    NumSides = 7;
                    SideLength = O / 7;
                    break;
                case "OCTAGON":
                    NumSides = 8;
                    SideLength = O / 8;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
      
        public void GetVertices()
        {
            // Vinkel i radianer
            Angles = (2 * Math.PI) / NumSides;
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
                XCorner = (X + Circumradius * Math.Sin(i * Angles + Offset));
                YCorner = (Y + Circumradius * Math.Cos(i * Angles + Offset));

                // Creating a list that will be used to create a point object
                List<double> pointArgs = new List<double>();
                pointArgs.Add(XCorner);
                pointArgs.Add(YCorner);
                pointArgs.Add(0);
                Vertices.Add(new Point(pointArgs));
            }
        }
    }
}
