namespace GeometryLib.Tests;

public class Circle2DTests
{
    /// Тест корректной инициализации круга
    [Fact]
    public void Init_Circle_Correctly()
    {
        Point2D center = new Point2D(0, 0);
        const double circleRadius = 2.0;
        Circle2D circle = new Circle2D(center, circleRadius);
        Assert.Equal(center, circle.Center);
        Assert.Equal(circleRadius, circle.Radius);
    }
    /// Тест инициализации круга с отрицательным радиусом
    [Fact]
    public void Cannot_Init_Circle()
    {
        Point2D center = new Point2D(0, 0);
        const double circleRadius = - 2.0;
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle2D(center, circleRadius));
    }
    
  
    [Fact]
    public void Can_Get_Diameter()
    {
        Point2D center = new Point2D(0, 0);
        const double circleRadius = 2.0;
        const double diameter = circleRadius * 2;
        Assert.Equal(diameter, new Circle2D(center, circleRadius).Diameter);
    }
    
    [Fact]
    public void Can_Get_Circumference()
    {
        Point2D center = new Point2D(0, 0);
        const double circleRadius = 2.0;
        const double circumference = 2 * Math.PI * circleRadius;
        Assert.Equal(circumference, new Circle2D(center, circleRadius).Circumference);
    }
    
    [Fact]
    public void Can_Get_Area()
    {
        Point2D center = new Point2D(0, 0);
        const double circleRadius = 2.0;
        double area = Math.PI * Math.Pow(circleRadius, 2);
        Assert.Equal(area, new Circle2D(center, circleRadius).Area);
    }

    //TODO: Тест метода DistanceToAnotherCircle
    //TODO: Тест метода DistanceTo (перегруженный метод) (перегруженный метод [Point2D, Circle2D])
    //TODO: Тест метода IntersectsWith
    //TODO: Тест метода Contains (перегруженный метод [Point2D, Circle2D])
}