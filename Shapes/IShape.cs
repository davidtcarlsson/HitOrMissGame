
namespace ProjektarbeteV2
{
    public interface IShape
    {
        double Area { get; }
        string Name { get; }
        bool IsPointInside(Point point);
    }
}