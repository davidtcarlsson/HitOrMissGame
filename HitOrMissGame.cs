using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
    class HitOrMissGame
    {
        public Dictionary<string, int> ShapeScore { get; private set; }
        public List<IShape> Shapes { get; private set; }
        public List<Point> Points { get; private set; }

        public HitOrMissGame(string[] args) 
        {
            Points = GetPoints(RemoveWhitespace(args[0]));
            Shapes = GetShapes(RemoveWhitespace(args[1]));
            ShapeScore = GetShapeScores(RemoveWhitespace(args[2]));
        }

        public List<IShape> GetShapes(string input) 
        {
            // Lägg till try catch sist
            List<IShape> shapes = new List<IShape>();
            foreach (string s in input.Split(";"))
            {
                string[] shapeArgs = s.Split(",");
                string shapeType = shapeArgs[0];
                List<int> shapeParams = new List<int>();

                for (int i = 1; i < shapeArgs.Length; i++)
                {
                    if (!String.IsNullOrWhiteSpace(shapeArgs[i]))
                    {
                        shapeParams.Add(Int32.Parse(shapeArgs[i]));
                    }
                }

                if (shapeParams.Count == 3)
                {
                    switch (shapeType)
                    {
                        case "CIRCLE":
                            shapes.Add(new Circle(shapeParams));
                            break;
                        case "SQUARE":
                            shapes.Add(new Square(shapeParams));
                            break;
                        case "TRIANGLE":
                            shapes.Add(new Polygon(shapeType, shapeParams));
                            break;
                        case "PENTAGON":

                            break;
                        case "HEXAGON":

                            break;
                        case "HEPTAGON":

                            break;
                        case "OCTAGON":

                            break;
                        default:
                            
                            break;
                    }
                }
            }
            return shapes;
        }

        public List<Point> GetPoints(string input) 
        {
            // Lägg till try catch sist
            List<Point> points = new List<Point>();
            foreach (string s in input.Split(";"))
            {
                List<double> pointArgs = new List<double>();
                foreach (string k in s.Split(","))
                {
                    if (!String.IsNullOrWhiteSpace(k))
                    {
                        pointArgs.Add(Double.Parse(k));
                    }
                }
                if (pointArgs.Count == 3)
                {
                    points.Add(new Point(pointArgs));
                }
            }
            return points;
        }

        public Dictionary<string, int> GetShapeScores(string input) 
        {
            Dictionary<string, int> shapeScore = new Dictionary<string, int>();
            foreach (string s in input.Split(";"))
            {
                string[] shapeScoreArgs = s.Split(",");
                if (shapeScoreArgs.Length == 2)
                {
                    shapeScore.Add(shapeScoreArgs[0], Int32.Parse(shapeScoreArgs[1]));
                }
            }
            return shapeScore;
        }

        public double GetScore() 
        {
            // Lägg till try catch sist
            double score = 0;
            foreach (IShape s in Shapes)
            {
                foreach (Point p in Points)
                {
                    if (s.IsPointInside(p))
                    {
                        score += s.Area * ShapeScore[s.Name];
                    } else
                    {
                        score += (p.PointScore * ShapeScore[s.Name]) / 4;
                    }
                }
            }
            return score;
        }

        public string RemoveWhitespace(string input)
        {
            string s = string.Empty;
            foreach (char c in input)
            {
                if (c != ' ')
                {
                    s += c;
                }
            }
            return s;
        } 
    }
}