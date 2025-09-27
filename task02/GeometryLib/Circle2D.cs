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

    // Максимальное отклонение, при котором значения всё ещё считаются равными.
    private const double Tolerance = 1e-10;

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
        double result = Radius - p.DistanceTo(Center);
        return Math.Abs(result);
    }

    /// <summary>
    /// Возвращает расстояние между ближайшими друг к другу точками окружностей
    /// </summary>
    public double DistanceTo(Circle2D p)
    {
        double distanceBetweenCenters = Center.DistanceTo(p.Center);
        double sumOfTwoRadius = Radius + p.Radius;
        // Если центры окружностей не совпадают
        if (distanceBetweenCenters > 0)
        {
            // Если окружности находятся не друг в друге и не пересекаются
            if (sumOfTwoRadius < distanceBetweenCenters)
            {
                return distanceBetweenCenters - sumOfTwoRadius;
            }

            // Если одна окружность полностью внутри другой
            double minR = Math.Min(p.Radius, Radius);
            double maxR = Math.Max(p.Radius, Radius);
            if (distanceBetweenCenters + minR < maxR)
            {
                return maxR - (distanceBetweenCenters + minR);
            }
        }
        // Если центры окружностей совпадают, но радиусы разные
        else if (Math.Abs(p.Radius - Radius) > Tolerance)
        {
            return Math.Abs(p.Radius - Radius);
        }

        return 0;
    }

    /// <summary>
    /// Пересекаются ли окружности
    /// </summary>
    public bool IntersectsWith(Circle2D other)
    {
        double result = DistanceTo(other);
        return result < Tolerance;
    }

    /// <summary>
    /// Лежит ли точка внутри круга
    /// </summary>
    public bool Contains(Point2D p)
    {
        return Center.DistanceTo(p) <= Radius;
    }

    /// <summary>
    /// Лежит ли другой круг полностью внутри этого круга
    /// </summary>
    public bool Contains(Circle2D other)
    {
        double distanceBetweenCenters = Center.DistanceTo(other.Center);
        return (distanceBetweenCenters + other.Radius) <= Radius;
    }
}