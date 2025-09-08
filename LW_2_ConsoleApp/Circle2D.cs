namespace LW_2_ConsoleApp;

/// <summary>
/// Класс Circle2D представляет круг в двухмерном Евклидовом пространстве.
/// </summary>
//TODO: реализовать класс Circle2D 
public class Circle2D
{
    //TODO: - конструктор Circle2D(Point2D center, double radius) - изучить подробнее про конструкторы в C#
    
    // private Point2D _center;
    // private double _radius;
    // public Circle2D(Point2D center, double radius)
    // {
    //     //TODO: --- следует соблюдать инвариант: радиус круга должен быть положительными
    //     if (radius <= 0)
    //         throw new ArgumentOutOfRangeException(nameof(radius), "Радиус должен быть положительным.");
    //     _center = center;
    //     _radius = radius;
    // }
    
    //TODO: - свойство double Diameter, возвращающее диаметр
    //TODO: - свойство double Circumference, возвращающее длину окружности
    //TODO: - свойство double Area, возвращающее площадь круга
    private double _diameter;
    private double _circumference;
    private double _area;

    private static double DistanceTo(Point2D p)
    {
        //TODO: - метод double DistanceTo(Point2D p), возвращающий расстояние от данной точки до ближайшей точки окружности
        return 0.0;
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