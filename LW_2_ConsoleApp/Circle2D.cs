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
        Center = center;
        Radius = radius;
    }
    
    private Point2D Center { get; }
    private double Radius { get; }

    public double Diameter => Radius * 2;

    /// <summary>
    /// Возвращает длину окружности
    /// </summary>
    private double Circumference => 2 * Math.PI * Radius;
    
    /// <summary>
    /// Возвращает площадь круга
    /// </summary>
    private double Area => Math.PI * Math.Pow(Radius, 2);
    
    /// <summary>
    /// Возвращает расстояние от точки `p` до ближайшей точки окружности
    /// </summary>
    private double DistanceTo(Point2D p)
    {
        return Radius - p.DistanceTo(Center);
    }
    
    /// <summary>
    /// Возвращает расстояние между ближайшими друг к другу точками окружностей
    /// </summary>
    private double DistanceTo(Circle2D p)
    {
        var distanceBetweenCenters = Center.DistanceTo(p.Center);
        var result = distanceBetweenCenters - Radius - p.Radius;
        if (result > 0)
        {
            return result;
        }
        return 0;
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