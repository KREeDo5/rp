namespace GeometryLib;

/// <summary>
/// Структура Point2D представляет точку в двухмерном Евклидовом пространстве
/// </summary>
public readonly struct Point2D(double x, double y)
{
    private double X { get;  } = x;
    private double Y { get; } = y;
    
    // // Максимальное отклонение, при котором расстояние всё ещё считается равным.
    // public const double Tolerance = 1e-10;
    //
    // // Количество знаков после запятой у максимального отклонения.
    // public const int Precision = 10;
    
    /// <summary>
    /// TODO: ТРЕБУЕТ ПРОВЕРКИ
    /// Евклидово расстояние: sqrt((x1 - x2)^2 + (y1 - y2)^2)
    /// Длина кратчайшей прямой линии между двумя точками в многомерном пространстве,
    /// вычисляемая по обобщенной теореме Пифагора.
    /// </summary>
    public double DistanceTo(Point2D other)
    {
        return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
    }
    // public static bool operator ==(Point2D left, Point2D right) => left.Equals(right);
    //
    // public static bool operator !=(Point2D left, Point2D right) => left.Equals(right);
    //
    // public bool Equals(Point2D other)
    // {
    //     return Math.Abs(X - other.X) < Tolerance
    //            && Math.Abs(Y - other.Y) < Tolerance;
    // }
}