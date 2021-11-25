using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteV2
{
	class Polygon : IShape
	{
        public string Name { get; private set; } = "POLYGON";
        public double Area { get => (sLength * sLength * sides) / (double)(4 * Math.Tan((180 / sides) *  Math.PI / 180)); }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int O { get; private set; }
        public int sides{ get; private set; }
        public int sLength{ get; private set; }
        public double angles { get; private set; }
        public double offset { get; private set; }
        public double circumradius { get; private set; }
        public List<List<double>> Vertices = new List<List<double>>();
        public double XCorner;
        public double YCorner;
        public Polygon(List<int> args)
        {
            X = args[0];
            Y = args[1];
            O = args[2];

        }

        public bool IsPointInside(Point point)
        {
            bool IsHit = false;
			for (int i = 0; i < sides -1; i++)
			{
				/*
                if (Vertices[i])
				{

				}
                */
			}
            return true;
        }
        public void NumOfSides(string type)
        {
            switch (Name)
            {
                case "TRIANGLE":
                    Name = Name; 
                    sides = 3;
                    sLength = O / 3;
                    break;
                case "SQUARE":
                    sides = 4;
                    sLength = O / 4;
                    break;
                case "PENTAGON":
                    sides = 5;
                    sLength = O / 5;
                    break;
                case "HEXAGON":
                    sides = 6;
                    sLength = O / 6;
                    break;
                case "HEPTAGON":
                    sides = 7;
                    sLength = O / 7;
                    break;
                case "OCTAGON":
                    sides = 8;
                    sLength = O / 8;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        public void CircumRadiusCalc()
        {
            circumradius = sLength / 2 * Math.Sin(Math.PI / sides);
        
        }
        public void GetVertices()
        {
            angles = Math.PI * 2 / sides;
			if (sides % 2 == 0)
			{
                offset = angles / 2;
			}
			else
			{
                offset = 0;
			}

			for (int i = 0; i < sides; i++)
			{
               XCorner = (X + circumradius * Math.Sin(i * angles + offset));

               YCorner = (Y + circumradius * Math.Cos(i * angles + offset));
                List<double> XY = new List<double>();
                XY.Add(XCorner);
                XY.Add(YCorner);
                Vertices.Insert(i, XY);
                XY.Remove(XCorner);
                XY.Remove(YCorner);
            }
        }
    }
}
