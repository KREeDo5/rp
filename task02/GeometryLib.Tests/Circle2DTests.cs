namespace GeometryLib.Tests;

public class Circle2DTests
{
    //TODO: Тест корректной инициализации круга
    [Fact]
    public void Init_Circle_Correctly()
    {
        Point2D center = new Point2D(0, 0);
        const double circleRadius = 2.0;
        Circle2D circle = new Circle2D(center, circleRadius);
        Assert.Equal(center, circle.Center);
        Assert.Equal(circleRadius, circle.Radius);
    }
    //TODO: Тест инициализации круга с отрицательным радиусом
    [Fact]
    public void Cannot_Init_Circle()
    {
        Point2D center = new Point2D(0, 0);
        const double circleRadius = - 2.0;
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle2D(center, circleRadius));
    }

    //TODO: Тест получение свойства - Диаметра круга
    //TODO: Тест получение свойства - Длины окружности круга (Circumference)
    //TODO: Тест получение свойства - Площади круга (Area)

    //TODO: Тест метода DistanceToAnotherCircle
    //TODO: Тест метода DistanceTo (перегруженный метод) (перегруженный метод [Point2D, Circle2D])
    //TODO: Тест метода IntersectsWith
    //TODO: Тест метода Contains (перегруженный метод [Point2D, Circle2D])
}