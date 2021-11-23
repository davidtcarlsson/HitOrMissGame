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

                switch (shapeType)
                {
                    case "CIRCLE":
                        shapes.Add(new Circle(shapeParams));
                        break;
                    case "SQUARE":
                        shapes.Add(new Square(shapeParams));
                        break;
                    default:
                        break;
                }
            }
            return shapes;
        }

        public List<Point> GetPoints(string input) 
        {
            List<Point> points = new List<Point>();
            foreach (string s in input.Split(";"))
            {
                List<int> pointArgs = new List<int>();
                foreach (string k in s.Split(","))
                {
                    if (!String.IsNullOrWhiteSpace(k))
                    {
                        pointArgs.Add(Int32.Parse(k));
                    }
                }
                points.Add(new Point(pointArgs));
            }
            return points;
        }

        public Dictionary<string, int> GetShapeScores(string input) 
        {
            Dictionary<string, int> shapeScore = new Dictionary<string, int>();
            foreach (string s in input.Split(";"))
            {
                string[] shapeScoreArgs = s.Split(",");
                shapeScore.Add(shapeScoreArgs[0], Int32.Parse(shapeScoreArgs[1]));
            }
            return shapeScore;
        }

        public double GetScore() 
        {
            double score = 0;
            foreach (IShape s in Shapes)
            {
                foreach (Point p in Points)
                {
                    if (s.IsPointInside(p))
                    {
                        score += s.GetArea() * ShapeScore[s.GetName()];
                    } else
                    {
                        score += (p.PointScore * ShapeScore[s.GetName()]) / 4;
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