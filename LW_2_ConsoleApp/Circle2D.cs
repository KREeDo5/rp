namespace LW_2_ConsoleApp;

/// <summary>
/// Класс Circle2D представляет круг в двухмерном Евклидовом пространстве.
/// </summary>
//TODO: реализовать класс Circle2D 
public class Circle2D
{
    public Circle2D(Point2D center, double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "Радиус должен быть положительным.");
        }
        _center = center;
        _radius = radius;
    }
    
    private Point2D _center;
    private readonly double _radius;
    
    public double Diameter => _radius * 2;

    /// <summary>
    /// Возвращает длину окружности
    /// </summary>
    private double Circumference => 2 * Math.PI * _radius;
    
    /// <summary>
    /// Возвращает площадь круга
    /// </summary>
    private double Area => Math.PI * Math.Pow(_radius, 2);
    
    /// <summary>
    /// Возвращает расстояние от точки `p` до ближайшей точки окружности
    /// </summary>
    private double DistanceTo(Point2D p)
    {
        return _radius - p.DistanceTo(_center);
    }

    private static double DistanceTo(Circle2D p)
    {
        //TODO: - метод double DistanceTo(Circle2D p), возвращающий расстояние между ближайшими друг к другу точками окружностей
        return 0.0;
    }

    private static bool Contains(Point2D p)
    {
        //TODO: - метод bool Contains(Point2D p), проверяющий, лежит ли точка внутри круга
        return false;
    }

    private static bool IntersectsWith(Circle2D other)
    {
        //TODO: - метод bool IntersectsWith(Circle2D other), определяющий, пересекаются ли два круга
        return false;
    }

    private static bool Contains(Circle2D other)
    {
        //TODO: - метод bool Contains(Circle2D other), проверяющий, лежит ли другой круг полностью внутри этого круга
        return false;
    }
}