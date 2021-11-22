using System;

namespace ProjektarbeteV2
{
    public interface IShape
    {
        // Type -> För att få fram ShapeScore
        // Area
        double GetArea();
        bool IsPointInside(Point point);
        string GetName();
    }
}