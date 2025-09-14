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

    private double DistanceToAnotherCircle(Circle2D p)
    {
        double distanceBetweenCenters = Center.DistanceTo(p.Center);
        return distanceBetweenCenters - Radius - p.Radius;
    }

    /// <summary>
    /// Возвращает расстояние между ближайшими друг к другу точками окружностей
    /// </summary>
    private double DistanceTo(Circle2D p)
    {
        double result = DistanceToAnotherCircle(p);
        if (result > 0)
        {
            return result;
        }

        return 0;
    }

    /// <summary>
    /// Лежит ли точка внутри круга
    /// </summary>
    private bool Contains(Point2D p)
    {
        return Center.DistanceTo(p) <= Radius;
    }

    /// <summary>
    /// Пересекаются ли окружности
    /// </summary>
    private bool IntersectsWith(Circle2D other)
    {
        double result = DistanceToAnotherCircle(other);
        return result <= 0;
    }

    /// <summary>
    /// Лежит ли другой круг полностью внутри этого круга
    /// </summary>
    private bool Contains(Circle2D other)
    {
        return (Center.DistanceTo(other.Center) + other.Radius) <= Radius;
    }
}