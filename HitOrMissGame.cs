using System;
using System.Collections.Generic;

namespace ProjektarbeteV2
{
    class HitOrMissGame
    {
        public Dictionary<string, int> ShapeScore = new Dictionary<string, int>();
        public List<IShape> Shapes = new List<IShape>();
        public List<Point> Points = new List<Point>();

        public HitOrMissGame(string[] args) 
        {
            AddPoints(RemoveWhitespace(args[0]));
            AddShapes(RemoveWhitespace(args[1]));
            AddShapeScores(RemoveWhitespace(args[2]));
        }

        public void Start() 
        {
            // Prints out the rounded score
            System.Console.WriteLine(Math.Round(GetScore(), 0));
        }

        public void AddShapes(string input) 
        {
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
                        Shapes.Add(new Circle(shapeParams));
                        break;
                    case "SQUARE":
                        Shapes.Add(new Square(shapeParams));
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddPoints(string input) 
        {
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
                Points.Add(new Point(pointArgs));
            }
        }

        public void AddShapeScores(string input) 
        {
            foreach (string s in input.Split(";"))
            {
                string[] shapeScoreArgs = s.Split(",");
                ShapeScore.Add(shapeScoreArgs[0], Int32.Parse(shapeScoreArgs[1]));
            }
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