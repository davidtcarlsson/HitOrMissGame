using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjektarbeteV2
{
    class HitOrMissGame
    {
        public Dictionary<string, double> ShapeScore { get; private set; }
        public List<IShape> Shapes { get; private set; }
        public List<Point> Points { get; private set; }

        public HitOrMissGame(string[] args) 
        {
            Points = GetPoints(Parse(args[0]));
            Shapes = GetShapes(Parse(args[1]));
            ShapeScore = GetShapeScores(Parse(args[2]));
        }

        public List<string> Parse(string input) 
        {
            // Remove the whitespace
            string trimmed = String.Concat(input.Where(x => !Char.IsWhiteSpace(x)));

            // Return a list with each argument where the empty elements are removed
            return trimmed.Split(";").Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        public List<IShape> GetShapes(List<string> input) 
        {
            // Define the numberFormatInfo so that we are able to convert negative nums to double
            // For example "-20" to -20
            var format = new NumberFormatInfo();
            format.NegativeSign = "-";
            List<IShape> shapes = new List<IShape>();

            foreach (string s in input)
            {
                string[] shapeArgs = s.Split(",");
                string shapeName = shapeArgs[0];
                List<double> shapeParams = new List<double>();
                for (int i = 1; i < shapeArgs.Length; i++)
                {    
                    // Loop through and add the parameters to the list (Skipping the first one)
                    shapeParams.Add(Double.Parse(shapeArgs[i], NumberStyles.AllowLeadingSign, format));
                }

                try
                {
                        switch (shapeName)
                    {
                        case "CIRCLE":
                            shapes.Add(new Circle(shapeParams));
                            break;
                        case "TRIANGLE":
                            shapes.Add(new Polygon(shapeName, shapeParams));
                            break;
                        case "SQUARE":
                            shapes.Add(new Polygon(shapeName, shapeParams));
                            break;
                        case "PENTAGON":
                            shapes.Add(new Polygon(shapeName, shapeParams));
                            break;
                        case "HEXAGON":
                            shapes.Add(new Polygon(shapeName, shapeParams));
                            break;
                        case "HEPTAGON":
                            shapes.Add(new Polygon(shapeName, shapeParams));
                            break;
                        case "OCTAGON":
                            shapes.Add(new Polygon(shapeName, shapeParams));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Your input for the shapes is incorrect.");
                    Console.WriteLine("It should follow this format: SHAPE, X, Y, PERIMETER.");
                    Console.WriteLine("Each point should also be separated with a ‘;’\n");
                    Console.Write("Press ENTER to exit the program.");
                    Console.ReadLine();
                    System.Environment.Exit(0);
                    throw;
                }
            }
            return shapes;
        }

        public List<Point> GetPoints(List<string> input) 
        {
            List<Point> points = new List<Point>();
            
            foreach (string s in input)
            {
                try
                {
                    // Convert the string array to a List<double> which we can pass to the Point class 
                    List<double> pointArgs = s.Split(",").Select(x => Double.Parse(x)).ToList();
                    points.Add(new Point(pointArgs)); 
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Your input for the points is incorrect.");
                    Console.WriteLine("It should follow this format: X, Y, SCORE.");
                    Console.WriteLine("Each point should also be separated with a ‘;’\n");
                    Console.Write("Press ENTER to exit the program.");
                    Console.ReadLine();
                    System.Environment.Exit(0);
                }
            }
            return points;
        }

        public Dictionary<string, double> GetShapeScores(List<string> input) 
        {
            Dictionary<string, double> shapeScore = new Dictionary<string, double>();
            foreach (string s in input)
            {
                try
                {
                    string[] shapeScoreArgs = s.Split(",");
                    shapeScore.Add(shapeScoreArgs[0], Double.Parse(shapeScoreArgs[1])); 
                }
                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("Your input for the shape scores is incorrect.");
                    Console.WriteLine("It should follow this format: SHAPE, SHAPE_SCORE.");
                    Console.WriteLine("Each point should also be separated with a ‘;’\n");
                    Console.Write("Press ENTER to exit the program.");
                    Console.ReadLine();
                    System.Environment.Exit(0);
                }    
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
                        score += s.Area * ShapeScore[s.Name];
                    } else
                    {
                        score += (p.PointScore * ShapeScore[s.Name]) / 4;
                    }
                }
            }
            return score;
        }
    }
}