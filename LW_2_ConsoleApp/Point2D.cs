namespace LW_2_ConsoleApp;

/// <summary>
/// Структура Point2D представляет точку в двухмерном Евклидовом пространстве
/// </summary>
public readonly struct Point2D(double x, double y)
{
    public double X { get;  } = x;
    public double Y { get; } = y;

    /// <summary>
    /// Евклидово расстояние: sqrt((x1 - x2)^2 + (y1 - y2)^2)
    /// Длина кратчайшей прямой линии между двумя точками в многомерном пространстве,
    /// вычисляемая по обобщенной теореме Пифагора.
    /// </summary>
    public double DistanceTo(Point2D other)
    {
        return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
    }
}