namespace GeometryLib;

/// <summary>
/// Класс Circle2D представляет круг в двухмерном Евклидовом пространстве.
/// </summary>
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

    public Point2D Center { get; }

    public double Radius { get; }

    public double Diameter => Radius * 2;

    /// <summary>
    /// Возвращает длину окружности
    /// </summary>
    public double Circumference => 2 * Math.PI * Radius;

    /// <summary>
    /// Возвращает площадь круга
    /// </summary>
    public double Area => Math.PI * Math.Pow(Radius, 2);

    /// <summary>
    /// Возвращает расстояние от точки `p` до ближайшей точки окружности
    /// </summary>
    public double DistanceTo(Point2D p)
    {
        return Radius - p.DistanceTo(Center);
    }

    /// <summary>
    /// Возвращает расстояние между ближайшими друг к другу точками окружностей
    /// </summary>
    public double DistanceTo(Circle2D p)
    {   
        double distanceBetweenCenters = Center.DistanceTo(p.Center);
        double result = distanceBetweenCenters - Radius - p.Radius;
        if (result > 0)
        {
            return result;
        }

        return 0;
    }

    /// <summary>
    /// Пересекаются ли окружности
    /// </summary>
    public bool IntersectsWith(Circle2D other)
    {
        double result = DistanceTo(other);
        return result == 0;
    }
    
    /// <summary>
    /// Лежит ли точка внутри круга
    /// </summary>
    private bool Contains(Point2D p)
    {
        return Center.DistanceTo(p) <= Radius;
    }

    /// <summary>
    /// Лежит ли другой круг полностью внутри этого круга
    /// </summary>
    private bool Contains(Circle2D other)
    {
        return (Center.DistanceTo(other.Center) + other.Radius) <= Radius;
    }
}